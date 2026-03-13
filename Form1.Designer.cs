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
            Display = new RichTextBox();
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
            grupo_frec.SuspendLayout();
            grupo_formato.SuspendLayout();
            SuspendLayout();
            // 
            // boton_socorro
            // 
            boton_socorro.BackColor = Color.Red;
            boton_socorro.Location = new Point(89, 35);
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
            label_mmsi.Location = new Point(253, 15);
            label_mmsi.Name = "label_mmsi";
            label_mmsi.Size = new Size(50, 20);
            label_mmsi.TabIndex = 2;
            label_mmsi.Text = "MMSI:";
            // 
            // MMSI_in
            // 
            MMSI_in.Location = new Point(313, 12);
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
            nature_distress.Location = new Point(28, 195);
            nature_distress.Name = "nature_distress";
            nature_distress.Size = new Size(237, 28);
            nature_distress.TabIndex = 4;
            nature_distress.Visible = false;
            nature_distress.SelectedIndexChanged += nature_distress_SelectedIndexChanged;
            // 
            // Display
            // 
            Display.Location = new Point(79, 240);
            Display.Name = "Display";
            Display.Size = new Size(428, 103);
            Display.TabIndex = 8;
            Display.Text = "";
            Display.Visible = false;
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
            grupo_frec.Location = new Point(291, 58);
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
            grupo_formato.Location = new Point(483, 58);
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
            boton_enviar.Location = new Point(576, 258);
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
            label_distress.Location = new Point(28, 172);
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
            combox_sig_com.Location = new Point(271, 195);
            combox_sig_com.Name = "combox_sig_com";
            combox_sig_com.Size = new Size(187, 28);
            combox_sig_com.TabIndex = 14;
            combox_sig_com.Visible = false;
            combox_sig_com.SelectedIndexChanged += combox_sig_com_SelectedIndexChanged;
            // 
            // label_com_sig
            // 
            label_com_sig.AutoSize = true;
            label_com_sig.Location = new Point(271, 172);
            label_com_sig.Name = "label_com_sig";
            label_com_sig.Size = new Size(187, 20);
            label_com_sig.TabIndex = 15;
            label_com_sig.Text = "Comunicaciones siguientes";
            label_com_sig.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 355);
            Controls.Add(label_com_sig);
            Controls.Add(combox_sig_com);
            Controls.Add(label_distress);
            Controls.Add(boton_enviar);
            Controls.Add(grupo_formato);
            Controls.Add(grupo_frec);
            Controls.Add(Display);
            Controls.Add(nature_distress);
            Controls.Add(MMSI_in);
            Controls.Add(label_mmsi);
            Controls.Add(boton_socorro);
            Name = "Form1";
            Text = "Transreceptor_v1";
            grupo_frec.ResumeLayout(false);
            grupo_frec.PerformLayout();
            grupo_formato.ResumeLayout(false);
            grupo_formato.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button boton_socorro;
        private Label label_mmsi;
        private TextBox MMSI_in;
        private ComboBox nature_distress;
        private RichTextBox Display;
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
    }
}
