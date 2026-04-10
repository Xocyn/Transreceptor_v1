using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace Transreceptor_v1
{
    public partial class Form1 : Form
    {
        private enum ModoFrecuencia { Ninguno, Frecuencias, Canal }

        string mmsi = "";
        StringBuilder resultadoConChequeo = new StringBuilder();
        List<int> ECC = new List<int>();
        bool VHF = false;
        bool _updatingUI = false; // Para evitar eventos recursivos
        ModoFrecuencia _modoActual = ModoFrecuencia.Ninguno; // Controla si se usa canal o frecuencias
        public Form1()
        {
            InitializeComponent();
        }

        private void MMSI_in_TextChanged(object sender, EventArgs e)
        {
            mmsi = MMSI_in.Text;
            VerificarCondiciones();

            if (op_mf_hf.Checked && form_geografica.Checked && mmsi.Length == 9 && mmsi.All(char.IsDigit) && (cat_seguridad.Checked || cat_urgencia.Checked))
            { 
                boton_enviar.Visible = true;
            }

            //Display.Visible = true;
            //Display.Text = $"MMSI: {mmsi}"; // prueba display
        }

        private void form_all_ships_CheckedChanged(object sender, EventArgs e)
        {
            if (form_all_ships.Checked && (op_vhf.Checked || op_mf_hf.Checked))
            {
                categoria.Visible = true;
                label1.Visible = true;
                txt_tx.Visible = true;
                label2.Visible = true;
                txt_rx.Visible = true;
                label3.Visible = true;
                canal_box.Visible = true;
            }
            else
            {
                categoria.Visible = false;
                label1.Visible = false;
                txt_tx.Visible = false;
                label2.Visible = false;
                txt_rx.Visible = false;
                label3.Visible = false;
                canal_box.Visible = false;
                txt_tx.Clear();
                txt_rx.Clear();
                canal_box.SelectedIndex = -1;
                txt_tx.Enabled = true;
                txt_rx.Enabled = true;
                canal_box.Enabled = true;
                _modoActual = ModoFrecuencia.Ninguno;
            }
            VerificarCondiciones();
        }

        private void form_grupo_CheckedChanged(object sender, EventArgs e)
        {
            bool form_g = form_grupo.Checked;

        }

        private void boton_socorro_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Confirma que desea enviar una señal de SOCORRO?",
                "Confirmación de Socorro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.Yes)
            {
                nature_distress.Visible = true;
                label_distress.Visible = true;
                label_com_sig.Visible = true;
                combox_sig_com.Visible = true;
            }
        }

        private void nature_distress_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (nature_distress.SelectedIndex != -1)
            //{
            //    nature_distress.Enabled = false;
            //}

            VerificarCondiciones();
        }

        private void VerificarCondiciones()
        {
            bool frecuenciaSeleccionada = op_vhf.Checked || op_mf_hf.Checked;
            bool mmsiValido = MMSI_in.Text.Length == 9 && MMSI_in.Text.All(char.IsDigit);
            bool botonEnviarVisible = false;

            if (frecuenciaSeleccionada && mmsiValido)
            {
                // Condiciones para SOCORRO
                if (!form_all_ships.Checked && !form_geografica.Checked)
                {
                    bool distressSeleccionado = nature_distress.SelectedIndex != -1;
                    bool comunicacionSeleccionada = combox_sig_com.SelectedIndex != -1;
                    botonEnviarVisible = distressSeleccionado && comunicacionSeleccionada;
                }
                // Condiciones para ALL SHIPS
                else if (form_all_ships.Checked)
                {
                    bool categoriaSeleccionada = cat_urgencia.Checked || cat_seguridad.Checked;
                    bool frecuenciaTxValida = !string.IsNullOrWhiteSpace(txt_tx.Text) && txt_tx.Text.All(char.IsDigit);
                    bool frecuenciaRxValida = !string.IsNullOrWhiteSpace(txt_rx.Text) && txt_rx.Text.All(char.IsDigit);
                    bool canalSeleccionado = canal_box.SelectedIndex != -1;
                    // Requiere categoría AND (ambas frecuencias XOR canal - uno u otro, no ambos)
                    bool frecuenciasSeleccionadas = frecuenciaTxValida && frecuenciaRxValida;
                    bool usaFrecuencias = frecuenciasSeleccionadas && canalSeleccionado == false;
                    bool usaCanal = canalSeleccionado && !frecuenciasSeleccionadas;
                    bool frecuenciasOCanal = usaFrecuencias || usaCanal;
                    botonEnviarVisible = categoriaSeleccionada && frecuenciasOCanal;
                }
                // Condiciones para GEOGRAFICA
                else if (form_geografica.Checked)
                {
                    bool categoriaSeleccionada = cat_urgencia.Checked || cat_seguridad.Checked;
                    bool frecuenciaTxValida = !string.IsNullOrWhiteSpace(txt_tx.Text) && txt_tx.Text.All(char.IsDigit);
                    bool frecuenciaRxValida = !string.IsNullOrWhiteSpace(txt_rx.Text) && txt_rx.Text.All(char.IsDigit);
                    bool canalSeleccionado = canal_box.SelectedIndex != -1;
                    // Requiere categoría AND (ambas frecuencias XOR canal - uno u otro, no ambos)
                    bool frecuenciasSeleccionadas = frecuenciaTxValida && frecuenciaRxValida;
                    bool usaFrecuencias = frecuenciasSeleccionadas && canalSeleccionado == false;
                    bool usaCanal = canalSeleccionado && !frecuenciasSeleccionadas;
                    bool frecuenciasOCanal = usaFrecuencias || usaCanal;
                    botonEnviarVisible = (op_mf_hf.Checked && mmsiValido && categoriaSeleccionada && frecuenciasOCanal);
                }
            }

            boton_enviar.Visible = botonEnviarVisible;
        }
        private void MMSI_in_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números o tecla de borrar
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limitar a 9 caracteres
            if (MMSI_in.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void op_vhf_CheckedChanged(object sender, EventArgs e)
        {
            VHF = true;
            if (form_all_ships.Checked && (op_vhf.Checked || op_mf_hf.Checked))
            {
                categoria.Visible = true;
                label1.Visible = true;
                txt_tx.Visible = true;
                label2.Visible = true;
                txt_rx.Visible = true;
                label3.Visible = true;
                canal_box.Visible = true;
            }
            else
            {
                categoria.Visible = false;
                label1.Visible = false;
                txt_tx.Visible = false;
                label2.Visible = false;
                txt_rx.Visible = false;
                label3.Visible = false;
                canal_box.Visible = false;
            }
            VerificarCondiciones();
        }

        private void op_mf_hf_CheckedChanged(object sender, EventArgs e)
        {
            VHF = false;
            VerificarCondiciones();
        }

        private void boton_enviar_Click(object sender, EventArgs e)
        {
            if (!form_all_ships.Checked && !form_geografica.Checked)
            {
                // Enviar mensaje de SOCORRO
                EnviarSocorro();
            }
            else if (form_all_ships.Checked)
            {
                // Enviar mensaje ALL SHIPS
                EnviarAllShips();
            }
            else if (form_geografica.Checked)
            {
                EnviarGeografica();
            }
        }

        private void EnviarSocorro()
        {
            Convertir.ConvertirNumero(112, resultadoConChequeo); Convertir.ConvertirNumero(112, resultadoConChequeo); ECC.Add(112);
            mmsi = MMSI_in.Text;
            Socorro.MMSI(resultadoConChequeo, ECC, mmsi);
            int codigoDistress = nature_distress.SelectedIndex;
            Socorro.NatureofDistress(resultadoConChequeo, ECC, codigoDistress);
            Socorro.Posicion(resultadoConChequeo, ECC);
            int comunicacionSeleccionada = combox_sig_com.SelectedIndex;
            Socorro.Comunicacionsig(resultadoConChequeo, ECC, comunicacionSeleccionada);
            Convertir.ConvertirNumero(127, resultadoConChequeo); ECC.Add(127); // ECC solo un EOS
            Convertir.ConvertirNumero(Mod2Sum7Bits(ECC), resultadoConChequeo); // ECC calculado 
            Convertir.ConvertirNumero(127, resultadoConChequeo); Convertir.ConvertirNumero(127, resultadoConChequeo);

            List<int> phasignseq = new List<int> { 125, 111, 125, 110, 125, 109, 125, 108, 125, 107, 125, 106 }; // faltan 105 y 104
            StringBuilder pss = new StringBuilder();

            foreach (int ps in phasignseq)
            {
                Convertir.ConvertirNumero(ps, pss);
            }

            List<int> inicio_rx = new List<int> { 105, 104 }; // agrego los 105 y 104 al inicio del Rx
            StringBuilder rx = new StringBuilder();
            foreach (int pf in inicio_rx)
            {
                Convertir.ConvertirNumero(pf, rx);
            }
            rx.Append(resultadoConChequeo); // armo los Rx 

            StringBuilder resultado = new StringBuilder();

            for (int i = 0; i < resultadoConChequeo.Length; i += 10)
            {
                // Extraer 10 caracteres de resultadoConChequeo (o menos en la última iteración)
                int longitud = Math.Min(10, resultadoConChequeo.Length - i);
                string aux = resultadoConChequeo.ToString(i, longitud);
                resultado.Append(aux);

                // Extraer 10 caracteres de rx (o menos en la última iteración)
                longitud = Math.Min(10, rx.Length - i);
                string aux2 = rx.ToString(i, longitud);
                resultado.Append(aux2);
            }

            pss.Append(resultado);
            StringBuilder dot = new StringBuilder();

            for (int i = 0; i <= 20; i += 1)
            {
                dot.Append(i % 2 == 0 ? "0" : "1");
            }
            dot.Append(pss);

            string rutadesalida = AppDomain.CurrentDomain.BaseDirectory;

            string archivoFinal = Path.Combine(rutadesalida, "prueba_transreceptor.txt");

            //File.WriteAllText(archivoFinal, pss.ToString().TrimEnd());
            // CON DOT
            File.WriteAllText(archivoFinal, dot.ToString().TrimEnd());

            // MODULACION Y REPRODUCCION DE AUDIO
            BFSKModulator.GenerateWav(archivoFinal, Path.Combine(rutadesalida, "prueba_transreceptor.wav"), VHF);
            AudioPlayer.Play(Path.Combine(rutadesalida, "prueba_transreceptor.wav"));

            ECC.Clear();
            resultadoConChequeo.Clear();
            pss.Clear();
            rx.Clear();
            resultado.Clear();
            dot.Clear();

            //nature_distress.Visible = false;
            //label_distress.Visible = false;
            //label_com_sig.Visible = false;
            //combox_sig_com.Visible = false;
            //boton_enviar.Visible = false;
            //nature_distress.SelectedIndex = -1;
            //combox_sig_com.SelectedIndex = -1;
        }

        private void EnviarAllShips()
        {
            // TODO: Implementar lógica para mensaje ALL SHIPS
            // Aquí van las diferentes líneas de código para ALL SHIPS
            Convertir.ConvertirNumero(116, resultadoConChequeo); Convertir.ConvertirNumero(116, resultadoConChequeo); ECC.Add(116);
            bool esSeguridad = cat_seguridad.Checked;
            if (esSeguridad)
            {
                Convertir.ConvertirNumero(108, resultadoConChequeo); ECC.Add(108);
            }
            else
            {
                Convertir.ConvertirNumero(110, resultadoConChequeo); ECC.Add(110);
            }
            mmsi = MMSI_in.Text;
            Socorro.MMSI(resultadoConChequeo, ECC, mmsi);
            ////PRIMER TELECOMANDO////
            if (op_mf_hf.Checked)
            {
                Convertir.ConvertirNumero(109, resultadoConChequeo); ECC.Add(109);
            }
            else
            {
                Convertir.ConvertirNumero(100, resultadoConChequeo); ECC.Add(100); // FIJO ALL MODES --> primer telecomando    
            }

            ////SEGUNDO TELECOMANDO////
            if (nave_medica.Checked)
            {
                Convertir.ConvertirNumero(111, resultadoConChequeo); ECC.Add(111);
            }
            else if (nave_aeronave.Checked)
            {
                Convertir.ConvertirNumero(110, resultadoConChequeo); ECC.Add(110);
            }
            else
            {
                Convertir.ConvertirNumero(126, resultadoConChequeo); ECC.Add(126); // NO INFO --> segundo telecomando
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Enviar datos según el modo seleccionado
            if (_modoActual == ModoFrecuencia.Frecuencias)
            {
                // Si el primer simbolo no es 0-1-2 descartar y si es menor a la longitud deseada agregar 0's o descart
                // FRECUENCIAS TX/RX
                string frecuenciaRx = txt_rx.Text;
                General.Frec(resultadoConChequeo, ECC, frecuenciaRx);

                string frecuenciaTx = txt_tx.Text;
                General.Frec(resultadoConChequeo, ECC, frecuenciaTx);
            }
            else if (_modoActual == ModoFrecuencia.Canal)
            {
                // CANAL
                string canal = string.Concat((canal_box.SelectedItem?.ToString() ?? string.Empty).Where(char.IsDigit));
                General.Frec(resultadoConChequeo, ECC, canal);
                General.Frec(resultadoConChequeo, ECC, canal);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Convertir.ConvertirNumero(127, resultadoConChequeo); ECC.Add(127); // ECC solo un EOS
            Convertir.ConvertirNumero(Mod2Sum7Bits(ECC), resultadoConChequeo); // ECC calculado 
            Convertir.ConvertirNumero(127, resultadoConChequeo); Convertir.ConvertirNumero(127, resultadoConChequeo);

            List<int> phasignseq = new List<int> { 125, 111, 125, 110, 125, 109, 125, 108, 125, 107, 125, 106 }; // faltan 105 y 104
            StringBuilder pss = new StringBuilder();

            foreach (int ps in phasignseq)
            {
                Convertir.ConvertirNumero(ps, pss);
            }

            List<int> inicio_rx = new List<int> { 105, 104 }; // agrego los 105 y 104 al inicio del Rx
            StringBuilder rx = new StringBuilder();
            foreach (int pf in inicio_rx)
            {
                Convertir.ConvertirNumero(pf, rx);
            }
            rx.Append(resultadoConChequeo); // armo los Rx 

            StringBuilder resultado = new StringBuilder();

            for (int i = 0; i < resultadoConChequeo.Length; i += 10)
            {
                // Extraer 10 caracteres de resultadoConChequeo (o menos en la última iteración)
                int longitud = Math.Min(10, resultadoConChequeo.Length - i);
                string aux = resultadoConChequeo.ToString(i, longitud);
                resultado.Append(aux);

                // Extraer 10 caracteres de rx (o menos en la última iteración)
                longitud = Math.Min(10, rx.Length - i);
                string aux2 = rx.ToString(i, longitud);
                resultado.Append(aux2);
            }

            pss.Append(resultado);
            StringBuilder dot = new StringBuilder();

            for (int i = 0; i <= 20; i += 1)
            {
                dot.Append(i % 2 == 0 ? "0" : "1");
            }
            dot.Append(pss);

            string rutadesalida = AppDomain.CurrentDomain.BaseDirectory;

            string archivoFinal = Path.Combine(rutadesalida, "prueba_transreceptor.txt");

            //File.WriteAllText(archivoFinal, pss.ToString().TrimEnd());
            // CON DOT
            File.WriteAllText(archivoFinal, dot.ToString().TrimEnd());

            // MODULACION Y REPRODUCCION DE AUDIO
            BFSKModulator.GenerateWav(archivoFinal, Path.Combine(rutadesalida, "prueba_transreceptor.wav"), VHF);
            AudioPlayer.Play(Path.Combine(rutadesalida, "prueba_transreceptor.wav"));

            ECC.Clear();
            resultadoConChequeo.Clear();
            pss.Clear();
            rx.Clear();
            resultado.Clear();
            dot.Clear();

            // Resetear bloqueos después de enviar
            _updatingUI = true;
            txt_tx.Enabled = true;
            txt_rx.Enabled = true;
            canal_box.Enabled = true;
            _modoActual = ModoFrecuencia.Ninguno;
            _updatingUI = false;
            form_all_ships.Checked = false;
        }

        private void EnviarGeografica()
        {
            Convertir.ConvertirNumero(102, resultadoConChequeo); Convertir.ConvertirNumero(102, resultadoConChequeo); ECC.Add(102);

            // AREA FIJA //
            Convertir.ConvertirNumero(33, resultadoConChequeo); ECC.Add(33);
            Convertir.ConvertirNumero(80, resultadoConChequeo); ECC.Add(80);
            Convertir.ConvertirNumero(57, resultadoConChequeo); ECC.Add(57);
            Convertir.ConvertirNumero(05, resultadoConChequeo); ECC.Add(05);
            Convertir.ConvertirNumero(05, resultadoConChequeo); ECC.Add(05);

            // OCULTAR O NO SEGURIDAD/URGENCIA //

            if (nave_medica.Checked || nave_aeronave.Checked || cat_urgencia.Checked)
            {
                Convertir.ConvertirNumero(110, resultadoConChequeo); ECC.Add(110);
            }
            else if (cat_seguridad.Checked)
            {
                Convertir.ConvertirNumero(108, resultadoConChequeo); ECC.Add(108); 
            }

            mmsi = MMSI_in.Text;
            Socorro.MMSI(resultadoConChequeo, ECC, mmsi);
    
            Convertir.ConvertirNumero(109, resultadoConChequeo); ECC.Add(109); //Primer Telecomando fijo

            if (nave_medica.Checked && !nave_aeronave.Checked)
            {
                Convertir.ConvertirNumero(111, resultadoConChequeo); ECC.Add(111);
            }
            else if (!nave_medica.Checked && nave_aeronave.Checked)
            {
                Convertir.ConvertirNumero(110, resultadoConChequeo); ECC.Add(110);
            }
            else if (!nave_medica.Checked && !nave_aeronave.Checked)
            {
                Convertir.ConvertirNumero(126, resultadoConChequeo); ECC.Add(126); // NO INFO --> segundo telecomando
            }
            // Enviar datos según el modo seleccionado
            if (_modoActual == ModoFrecuencia.Frecuencias)
            {
                // Si el primer simbolo no es 0-1-2 descartar y si es menor a la longitud deseada agregar 0's o descart
                // FRECUENCIAS TX/RX
                string frecuenciaRx = txt_rx.Text;
                General.Frec(resultadoConChequeo, ECC, frecuenciaRx);

                string frecuenciaTx = txt_tx.Text;
                General.Frec(resultadoConChequeo, ECC, frecuenciaTx);
            }
            else if (_modoActual == ModoFrecuencia.Canal)
            {
                // CANAL
                string canal = string.Concat((canal_box.SelectedItem?.ToString() ?? string.Empty).Where(char.IsDigit));
                General.Frec(resultadoConChequeo, ECC, canal);
                General.Frec(resultadoConChequeo, ECC, canal);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Convertir.ConvertirNumero(127, resultadoConChequeo); ECC.Add(127); // ECC solo un EOS
            Convertir.ConvertirNumero(Mod2Sum7Bits(ECC), resultadoConChequeo); // ECC calculado 
            Convertir.ConvertirNumero(127, resultadoConChequeo); Convertir.ConvertirNumero(127, resultadoConChequeo);

            List<int> phasignseq = new List<int> { 125, 111, 125, 110, 125, 109, 125, 108, 125, 107, 125, 106 }; // faltan 105 y 104
            StringBuilder pss = new StringBuilder();

            foreach (int ps in phasignseq)
            {
                Convertir.ConvertirNumero(ps, pss);
            }

            List<int> inicio_rx = new List<int> { 105, 104 }; // agrego los 105 y 104 al inicio del Rx
            StringBuilder rx = new StringBuilder();
            foreach (int pf in inicio_rx)
            {
                Convertir.ConvertirNumero(pf, rx);
            }
            rx.Append(resultadoConChequeo); // armo los Rx 

            StringBuilder resultado = new StringBuilder();

            for (int i = 0; i < resultadoConChequeo.Length; i += 10)
            {
                // Extraer 10 caracteres de resultadoConChequeo (o menos en la última iteración)
                int longitud = Math.Min(10, resultadoConChequeo.Length - i);
                string aux = resultadoConChequeo.ToString(i, longitud);
                resultado.Append(aux);

                // Extraer 10 caracteres de rx (o menos en la última iteración)
                longitud = Math.Min(10, rx.Length - i);
                string aux2 = rx.ToString(i, longitud);
                resultado.Append(aux2);
            }

            pss.Append(resultado);
            StringBuilder dot = new StringBuilder();

            for (int i = 0; i <= 20; i += 1)
            {
                dot.Append(i % 2 == 0 ? "0" : "1");
            }
            dot.Append(pss);

            string rutadesalida = AppDomain.CurrentDomain.BaseDirectory;

            string archivoFinal = Path.Combine(rutadesalida, "prueba_transreceptor.txt");

            //File.WriteAllText(archivoFinal, pss.ToString().TrimEnd());
            // CON DOT
            File.WriteAllText(archivoFinal, dot.ToString().TrimEnd());

            // MODULACION Y REPRODUCCION DE AUDIO
            BFSKModulator.GenerateWav(archivoFinal, Path.Combine(rutadesalida, "prueba_transreceptor.wav"), VHF);
            AudioPlayer.Play(Path.Combine(rutadesalida, "prueba_transreceptor.wav"));

            ECC.Clear();
            resultadoConChequeo.Clear();
            pss.Clear();
            rx.Clear();
            resultado.Clear();
            dot.Clear();

            // Resetear bloqueos después de enviar
            _updatingUI = true;
            txt_tx.Clear();
            txt_rx.Clear();
            canal_box.SelectedIndex = -1;
            txt_tx.Enabled = true;
            txt_rx.Enabled = true;
            canal_box.Enabled = true;
            _modoActual = ModoFrecuencia.Ninguno;
            _updatingUI = false;
            form_geografica.Checked = false;
        }

        private void combox_sig_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (combox_sig_com.SelectedIndex != -1)
            //{
            //    combox_sig_com.Enabled = false;
            //}

            VerificarCondiciones();
        }

        // PARA MI ESTE ES EL CORRECTO
        public static int checkECC(List<int> ECC)
        {
            if (ECC == null || ECC.Count == 0)
                return 0;

            // 1️ Sumar todos los elementos
            int sum = ECC.Sum();

            // 2️ Aplicar máscara de 7 bits (0x7F = 127 = 01111111)
            int ecc = sum & 0x7F;

            return ecc;
        }

        // ESTE ES EL QUE "SUPUESTAMENTE" ES CORRECTO
        public static int Mod2Sum7Bits(List<int> values)
        {
            if (values == null || values.Count == 0)
                return 0;

            int result = 0;

            foreach (int v in values)
            {
                result ^= v; // XOR acumulativo (suma módulo 2)
            }

            // Nos quedamos con los 7 bits menos significativos
            result &= 0x7F;

            return result;
        }

        private void Frec_Tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números o tecla de borrar
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limitar a 6 caracteres
            if (MMSI_in.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            VerificarCondiciones();
        }

        private void NumericKeyPress_6Digits(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números o tecla de borrar
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Limitar a 6 caracteres
            if (sender is TextBox textBox && textBox.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_tx_TextChanged(object sender, EventArgs e)
        {
            if (_updatingUI) return;

            // Si hay contenido en TX, bloquear el canal
            if (!string.IsNullOrWhiteSpace(txt_tx.Text))
            {
                _updatingUI = true;
                canal_box.SelectedIndex = -1;
                canal_box.Enabled = false;
                _modoActual = ModoFrecuencia.Frecuencias;
                _updatingUI = false;
            }
            else if (string.IsNullOrWhiteSpace(txt_rx.Text))
            {
                // Si ambas frecuencias están vacías, habilitar canal
                _updatingUI = true;
                canal_box.Enabled = true;
                _modoActual = ModoFrecuencia.Ninguno;
                _updatingUI = false;
            }

            VerificarCondiciones();
        }

        private void txt_rx_TextChanged(object sender, EventArgs e)
        {
            if (_updatingUI) return;

            // Si hay contenido en RX, bloquear el canal
            if (!string.IsNullOrWhiteSpace(txt_rx.Text))
            {
                _updatingUI = true;
                canal_box.SelectedIndex = -1;
                canal_box.Enabled = false;
                _modoActual = ModoFrecuencia.Frecuencias;
                _updatingUI = false;
            }
            else if (string.IsNullOrWhiteSpace(txt_tx.Text))
            {
                // Si ambas frecuencias están vacías, habilitar canal
                _updatingUI = true;
                canal_box.Enabled = true;
                _modoActual = ModoFrecuencia.Ninguno;
                _updatingUI = false;
            }

            VerificarCondiciones();
        }

        private void canal_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updatingUI) return;

            // Si se selecciona un canal, bloquear las frecuencias
            if (canal_box.SelectedIndex != -1)
            {
                _updatingUI = true;
                txt_tx.Clear();
                txt_rx.Clear();
                txt_tx.Enabled = false;
                txt_rx.Enabled = false;
                _modoActual = ModoFrecuencia.Canal;
                _updatingUI = false;
            }
            // Si se deselecciona el canal, habilitar frecuencias
            else
            {
                _updatingUI = true;
                txt_tx.Enabled = true;
                txt_rx.Enabled = true;
                _modoActual = ModoFrecuencia.Ninguno;
                _updatingUI = false;
            }

            VerificarCondiciones();
        }

        private void radioButton_categoria_CheckedChanged(object sender, EventArgs e)
        {
            VerificarCondiciones();
        }

        private void form_geografica_CheckedChanged(object sender, EventArgs e)
        {
            categoria.Visible = true;
            label1.Visible = true;
            txt_tx.Visible = true;
            label2.Visible = true;
            txt_rx.Visible = true;
            label3.Visible = true;
            canal_box.Visible = true;
            VerificarCondiciones();
        }
    }

}