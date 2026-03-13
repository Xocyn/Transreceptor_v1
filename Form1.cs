using System.Text;

namespace Transreceptor_v1
{
    public partial class Form1 : Form
    {
        string mmsi = "";
        StringBuilder resultadoConChequeo = new StringBuilder();
        List<int> ECC = new List<int>();
        bool VHF = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void MMSI_in_TextChanged(object sender, EventArgs e)
        {
            mmsi = MMSI_in.Text;
            VerificarCondiciones();
            //Display.Visible = true;
            //Display.Text = $"MMSI: {mmsi}"; // prueba display
        }

        private void form_all_ships_CheckedChanged(object sender, EventArgs e)
        {
            //bool form_allships = form_all_ships.Checked;
            //Display.Visible = true;
            //Display.Text = $"{form_allships}";
        }

        private void form_grupo_CheckedChanged(object sender, EventArgs e)
        {
            bool form_g = form_grupo.Checked;
            Display.Visible = true;
            Display.Text = $"{form_g}";
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

            bool distressSeleccionado = nature_distress.SelectedIndex != -1;

            bool comunicacionSeleccionada = combox_sig_com.SelectedIndex != -1;

            if (frecuenciaSeleccionada && mmsiValido && distressSeleccionado && comunicacionSeleccionada)
            {
                boton_enviar.Visible = true;
            }
            else
            {
                boton_enviar.Visible = false;
            }
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
            VerificarCondiciones();

        }

        private void op_mf_hf_CheckedChanged(object sender, EventArgs e)
        {
            VHF = false;
            VerificarCondiciones();

        }

        private void boton_enviar_Click(object sender, EventArgs e)
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
            Convertir.ConvertirNumero(checkECC(ECC), resultadoConChequeo); // ECC calculado 
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

            string rutadesalida = @"C:\Users\playg\Desktop\WORK\Programas LSD\Pruebas\Dem_v0\Dem_v0\Dem_v0\bin\Debug\net10.0";

            string archivoFinal = Path.Combine(rutadesalida, "prueba_transreceptor.txt");

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

        private void combox_sig_com_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (combox_sig_com.SelectedIndex != -1)
            //{
            //    combox_sig_com.Enabled = false;
            //}

            VerificarCondiciones();
        }

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
    }

}
