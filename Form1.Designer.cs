namespace Transreceptor_v1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            boton_socorro = new Button();
            label_mmsi = new Label();
            MMSI_in = new TextBox();
            nature_distress = new ComboBox();
            op_mf_hf = new RadioButton();
            grupo_frec = new GroupBox();
            op_vhf = new RadioButton();
            grupo_formato = new GroupBox();
            form_geografica = new RadioButton();
            form_individual = new RadioButton();
            form_grupo = new RadioButton();
            form_all_ships = new RadioButton();
            boton_enviar = new Button();
            label_distress = new Label();
            combox_sig_com = new ComboBox();
            label_com_sig = new Label();
            categoria = new GroupBox();
            cat_urgencia = new RadioButton();
            cat_seguridad = new RadioButton();
            txt_tx = new TextBox();
            label1 = new Label();
            txt_rx = new TextBox();
            label2 = new Label();
            label3 = new Label();
            canal_box = new ComboBox();
            tipo_de_nave = new GroupBox();
            nave_aeronave = new RadioButton();
            nave_medica = new RadioButton();
            nave_comun = new RadioButton();
            MMSI_RX = new TextBox();
            label_MMSIRX = new Label();
            grupo_frec.SuspendLayout();
            grupo_formato.SuspendLayout();
            categoria.SuspendLayout();
            tipo_de_nave.SuspendLayout();
            SuspendLayout();
            // 
            // boton_socorro
            // 
            boton_socorro.BackColor = Color.Red;
            boton_socorro.Location = new Point(200, 50);
            boton_socorro.Name = "boton_socorro";
            boton_socorro.Size = new Size(126, 115);
            boton_socorro.TabIndex = 0;
            boton_socorro.Text = "SOCORRO";
            boton_socorro.UseVisualStyleBackColor = false;
            boton_socorro.Click += boton_socorro_Click;
            // 
            // label_mmsi
            // 
            label_mmsi.AutoSize = true;
            label_mmsi.Location = new Point(499, 24);
            label_mmsi.Name = "label_mmsi";
            label_mmsi.Size = new Size(50, 20);
            label_mmsi.TabIndex = 2;
            label_mmsi.Text = "MMSI:";
            // 
            // MMSI_in
            // 
            MMSI_in.Location = new Point(559, 21);
            MMSI_in.Name = "MMSI_in";
            MMSI_in.Size = new Size(125, 27);
            MMSI_in.TabIndex = 3;
            MMSI_in.TextChanged += MMSI_in_TextChanged;
            MMSI_in.KeyPress += MMSI_in_KeyPress;
            // 
            // nature_distress
            // 
            nature_distress.FormattingEnabled = true;
            nature_distress.Items.AddRange(new object[] { "Incendio, explosión", "Inundación", "Colisión", "Encalladura", "Escorado, en peligro de zozobra", "Naufragio", "Sin gobierno y a la deriva ", "Peligro no definido ", "Abandono del barco ", "Piratería/ataque a mano armada", "Hombre al agua" });
            nature_distress.Location = new Point(28, 210);
            nature_distress.Name = "nature_distress";
            nature_distress.Size = new Size(237, 28);
            nature_distress.TabIndex = 4;
            nature_distress.Visible = false;
            nature_distress.SelectedIndexChanged += nature_distress_SelectedIndexChanged;
            // 
            // op_mf_hf
            // 
            op_mf_hf.AutoSize = true;
            op_mf_hf.Location = new Point(20, 26);
            op_mf_hf.Name = "op_mf_hf";
            op_mf_hf.Size = new Size(74, 24);
            op_mf_hf.TabIndex = 9;
            op_mf_hf.TabStop = true;
            op_mf_hf.Text = "MF/HF";
            op_mf_hf.UseVisualStyleBackColor = true;
            op_mf_hf.CheckedChanged += op_mf_hf_CheckedChanged;
            // 
            // grupo_frec
            // 
            grupo_frec.Controls.Add(op_vhf);
            grupo_frec.Controls.Add(op_mf_hf);
            grupo_frec.Location = new Point(330, 73);
            grupo_frec.Name = "grupo_frec";
            grupo_frec.Size = new Size(128, 92);
            grupo_frec.TabIndex = 10;
            grupo_frec.TabStop = false;
            grupo_frec.Text = "Frecuencia";
            // 
            // op_vhf
            // 
            op_vhf.AutoSize = true;
            op_vhf.Location = new Point(20, 56);
            op_vhf.Name = "op_vhf";
            op_vhf.Size = new Size(57, 24);
            op_vhf.TabIndex = 10;
            op_vhf.TabStop = true;
            op_vhf.Text = "VHF";
            op_vhf.UseVisualStyleBackColor = true;
            op_vhf.CheckedChanged += op_vhf_CheckedChanged;
            // 
            // grupo_formato
            // 
            grupo_formato.Controls.Add(form_geografica);
            grupo_formato.Controls.Add(form_individual);
            grupo_formato.Controls.Add(form_grupo);
            grupo_formato.Controls.Add(form_all_ships);
            grupo_formato.Location = new Point(483, 73);
            grupo_formato.Name = "grupo_formato";
            grupo_formato.Size = new Size(210, 150);
            grupo_formato.TabIndex = 11;
            grupo_formato.TabStop = false;
            grupo_formato.Text = "Formato";
            // 
            // form_geografica
            // 
            form_geografica.AutoSize = true;
            form_geografica.Location = new Point(20, 116);
            form_geografica.Name = "form_geografica";
            form_geografica.Size = new Size(118, 24);
            form_geografica.TabIndex = 12;
            form_geografica.TabStop = true;
            form_geografica.Text = "GEOGRAFICA";
            form_geografica.UseVisualStyleBackColor = true;
            form_geografica.CheckedChanged += form_geografica_CheckedChanged;
            // 
            // form_individual
            // 
            form_individual.AutoSize = true;
            form_individual.Location = new Point(20, 86);
            form_individual.Name = "form_individual";
            form_individual.Size = new Size(111, 24);
            form_individual.TabIndex = 11;
            form_individual.TabStop = true;
            form_individual.Text = "INDIVIDUAL";
            form_individual.UseVisualStyleBackColor = true;
            form_individual.CheckedChanged += form_individual_CheckedChanged;
            // 
            // form_grupo
            // 
            form_grupo.AutoSize = true;
            form_grupo.Location = new Point(20, 56);
            form_grupo.Name = "form_grupo";
            form_grupo.Size = new Size(161, 24);
            form_grupo.TabIndex = 10;
            form_grupo.TabStop = true;
            form_grupo.Text = "GRUPO DE BARCOS";
            form_grupo.UseVisualStyleBackColor = true;
            form_grupo.CheckedChanged += form_grupo_CheckedChanged;
            // 
            // form_all_ships
            // 
            form_all_ships.AutoSize = true;
            form_all_ships.Location = new Point(20, 28);
            form_all_ships.Name = "form_all_ships";
            form_all_ships.Size = new Size(97, 24);
            form_all_ships.TabIndex = 9;
            form_all_ships.TabStop = true;
            form_all_ships.Text = "ALL SHIPS";
            form_all_ships.UseVisualStyleBackColor = true;
            form_all_ships.CheckedChanged += form_all_ships_CheckedChanged;
            // 
            // boton_enviar
            // 
            boton_enviar.BackColor = Color.Lime;
            boton_enviar.Location = new Point(619, 261);
            boton_enviar.Name = "boton_enviar";
            boton_enviar.Size = new Size(74, 61);
            boton_enviar.TabIndex = 12;
            boton_enviar.Text = "ENVIAR";
            boton_enviar.UseVisualStyleBackColor = false;
            boton_enviar.Visible = false;
            boton_enviar.Click += boton_enviar_Click;
            // 
            // label_distress
            // 
            label_distress.AutoSize = true;
            label_distress.Location = new Point(28, 187);
            label_distress.Name = "label_distress";
            label_distress.Size = new Size(237, 20);
            label_distress.TabIndex = 13;
            label_distress.Text = "Seleccione naturaleza del desastre";
            label_distress.TextAlign = ContentAlignment.TopCenter;
            label_distress.Visible = false;
            // 
            // combox_sig_com
            // 
            combox_sig_com.FormattingEnabled = true;
            combox_sig_com.Items.AddRange(new object[] { "F3E/G3E ALL MODES TP", "F3E/G3E DUPLEX TP", "J3E TP", "F1B/J2B TTY-FEC", "F1B/J2B TTY-ARQ", "Sin información" });
            combox_sig_com.Location = new Point(271, 210);
            combox_sig_com.Name = "combox_sig_com";
            combox_sig_com.Size = new Size(187, 28);
            combox_sig_com.TabIndex = 14;
            combox_sig_com.Visible = false;
            combox_sig_com.SelectedIndexChanged += combox_sig_com_SelectedIndexChanged;
            // 
            // label_com_sig
            // 
            label_com_sig.AutoSize = true;
            label_com_sig.Location = new Point(271, 187);
            label_com_sig.Name = "label_com_sig";
            label_com_sig.Size = new Size(187, 20);
            label_com_sig.TabIndex = 15;
            label_com_sig.Text = "Comunicaciones siguientes";
            label_com_sig.Visible = false;
            // 
            // categoria
            // 
            categoria.Controls.Add(cat_urgencia);
            categoria.Controls.Add(cat_seguridad);
            categoria.Location = new Point(28, 246);
            categoria.Name = "categoria";
            categoria.Size = new Size(128, 92);
            categoria.TabIndex = 11;
            categoria.TabStop = false;
            categoria.Text = "Categoria";
            categoria.Visible = false;
            // 
            // cat_urgencia
            // 
            cat_urgencia.AutoSize = true;
            cat_urgencia.Location = new Point(20, 56);
            cat_urgencia.Name = "cat_urgencia";
            cat_urgencia.Size = new Size(89, 24);
            cat_urgencia.TabIndex = 10;
            cat_urgencia.TabStop = true;
            cat_urgencia.Text = "Urgencia";
            cat_urgencia.UseVisualStyleBackColor = true;
            cat_urgencia.CheckedChanged += radioButton_categoria_CheckedChanged;
            // 
            // cat_seguridad
            // 
            cat_seguridad.AutoSize = true;
            cat_seguridad.Location = new Point(20, 26);
            cat_seguridad.Name = "cat_seguridad";
            cat_seguridad.Size = new Size(98, 24);
            cat_seguridad.TabIndex = 9;
            cat_seguridad.TabStop = true;
            cat_seguridad.Text = "Seguridad";
            cat_seguridad.UseVisualStyleBackColor = true;
            cat_seguridad.CheckedChanged += radioButton_categoria_CheckedChanged;
            // 
            // txt_tx
            // 
            txt_tx.Location = new Point(309, 258);
            txt_tx.Name = "txt_tx";
            txt_tx.Size = new Size(125, 27);
            txt_tx.TabIndex = 17;
            txt_tx.Visible = false;
            txt_tx.TextChanged += txt_tx_TextChanged;
            txt_tx.KeyPress += NumericKeyPress_6Digits;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new Point(182, 261);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 16;
            label1.Text = "Frecuencia de Tx:";
            label1.Visible = false;
            // 
            // txt_rx
            // 
            txt_rx.Location = new Point(309, 299);
            txt_rx.Name = "txt_rx";
            txt_rx.Size = new Size(125, 27);
            txt_rx.TabIndex = 19;
            txt_rx.Visible = false;
            txt_rx.TextChanged += txt_rx_TextChanged;
            txt_rx.KeyPress += NumericKeyPress_6Digits;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Location = new Point(182, 302);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 18;
            label2.Text = "Frecuencia de Rx:";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(503, 265);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 21;
            label3.Text = "Canal";
            label3.Visible = false;
            // 
            // canal_box
            // 
            canal_box.FormattingEnabled = true;
            canal_box.Items.AddRange(new object[] { "2187.5 kHz", "4207.5 kHz", "CH 70", "CH 16" });
            canal_box.Location = new Point(466, 288);
            canal_box.Name = "canal_box";
            canal_box.Size = new Size(122, 28);
            canal_box.TabIndex = 20;
            canal_box.Visible = false;
            canal_box.SelectedIndexChanged += canal_box_SelectedIndexChanged;
            // 
            // tipo_de_nave
            // 
            tipo_de_nave.Controls.Add(nave_aeronave);
            tipo_de_nave.Controls.Add(nave_medica);
            tipo_de_nave.Controls.Add(nave_comun);
            tipo_de_nave.ImeMode = ImeMode.On;
            tipo_de_nave.Location = new Point(25, 45);
            tipo_de_nave.Name = "tipo_de_nave";
            tipo_de_nave.Size = new Size(167, 120);
            tipo_de_nave.TabIndex = 11;
            tipo_de_nave.TabStop = false;
            tipo_de_nave.Text = "Tipo de Nave";
            // 
            // nave_aeronave
            // 
            nave_aeronave.AutoSize = true;
            nave_aeronave.Location = new Point(20, 86);
            nave_aeronave.Name = "nave_aeronave";
            nave_aeronave.Size = new Size(149, 24);
            nave_aeronave.TabIndex = 11;
            nave_aeronave.TabStop = true;
            nave_aeronave.Text = "Barcos/Aeronaves";
            nave_aeronave.UseVisualStyleBackColor = true;
            // 
            // nave_medica
            // 
            nave_medica.AutoSize = true;
            nave_medica.Location = new Point(20, 56);
            nave_medica.Name = "nave_medica";
            nave_medica.Size = new Size(79, 24);
            nave_medica.TabIndex = 10;
            nave_medica.TabStop = true;
            nave_medica.Text = "Medica";
            nave_medica.UseVisualStyleBackColor = true;
            // 
            // nave_comun
            // 
            nave_comun.AutoSize = true;
            nave_comun.Location = new Point(20, 26);
            nave_comun.Name = "nave_comun";
            nave_comun.Size = new Size(80, 24);
            nave_comun.TabIndex = 9;
            nave_comun.TabStop = true;
            nave_comun.Text = "Normal";
            nave_comun.UseVisualStyleBackColor = true;
            // 
            // MMSI_RX
            // 
            MMSI_RX.Location = new Point(336, 21);
            MMSI_RX.Name = "MMSI_RX";
            MMSI_RX.Size = new Size(125, 27);
            MMSI_RX.TabIndex = 23;
            MMSI_RX.Visible = false;
            MMSI_RX.TextChanged += MMSI_RX_TextChanged;
            MMSI_RX.KeyPress += MMSI_RX_KeyPress;
            // 
            // label_MMSIRX
            // 
            label_MMSIRX.AutoSize = true;
            label_MMSIRX.Location = new Point(258, 24);
            label_MMSIRX.Name = "label_MMSIRX";
            label_MMSIRX.RightToLeft = RightToLeft.No;
            label_MMSIRX.Size = new Size(72, 20);
            label_MMSIRX.TabIndex = 22;
            label_MMSIRX.Text = "MMSI RX:";
            label_MMSIRX.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 355);
            Controls.Add(MMSI_RX);
            Controls.Add(label_MMSIRX);
            Controls.Add(tipo_de_nave);
            Controls.Add(label3);
            Controls.Add(canal_box);
            Controls.Add(txt_rx);
            Controls.Add(label2);
            Controls.Add(txt_tx);
            Controls.Add(label1);
            Controls.Add(categoria);
            Controls.Add(label_com_sig);
            Controls.Add(combox_sig_com);
            Controls.Add(label_distress);
            Controls.Add(boton_enviar);
            Controls.Add(grupo_formato);
            Controls.Add(grupo_frec);
            Controls.Add(nature_distress);
            Controls.Add(MMSI_in);
            Controls.Add(label_mmsi);
            Controls.Add(boton_socorro);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Transreceptor_v1";
            grupo_frec.ResumeLayout(false);
            grupo_frec.PerformLayout();
            grupo_formato.ResumeLayout(false);
            grupo_formato.PerformLayout();
            categoria.ResumeLayout(false);
            categoria.PerformLayout();
            tipo_de_nave.ResumeLayout(false);
            tipo_de_nave.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button boton_socorro;
        private Label label_mmsi;
        private TextBox MMSI_in;
        private ComboBox nature_distress;
        private RadioButton op_mf_hf;
        private GroupBox grupo_frec;
        private RadioButton op_vhf;
        private GroupBox grupo_formato;
        private RadioButton form_geografica;
        private RadioButton form_individual;
        private RadioButton form_grupo;
        private RadioButton form_all_ships;
        private Button boton_enviar;
        private Label label_distress;
        private ComboBox combox_sig_com;
        private Label label_com_sig;
        private GroupBox categoria;
        private RadioButton cat_urgencia;
        private RadioButton cat_seguridad;
        private TextBox txt_tx;
        private Label label1;
        private TextBox txt_rx;
        private Label label2;
        private Label label3;
        private ComboBox canal_box;
        private RadioButton nave_aeronave;
        private RadioButton nave_medica;
        private RadioButton nave_comun;
        public GroupBox tipo_de_nave;
        private TextBox MMSI_RX;
        private Label label_MMSIRX;
    }
}
