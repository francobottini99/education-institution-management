namespace Capa.Presentacion.Formularios
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pnlPpal = new System.Windows.Forms.Panel();
            this.chbCicloLectivo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblIDDVS = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.cbxCiclosLectivos = new Capa.Presentacion.Controles.IDDVSCombobox();
            this.btnSalir = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnIniciar = new Capa.Presentacion.Controles.IDDVSButton();
            this.txtUsuario = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.txtPass = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.pnlPpal.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPpal
            // 
            this.pnlPpal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.pnlPpal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPpal.Controls.Add(this.chbCicloLectivo);
            this.pnlPpal.Controls.Add(this.cbxCiclosLectivos);
            this.pnlPpal.Controls.Add(this.btnSalir);
            this.pnlPpal.Controls.Add(this.btnIniciar);
            this.pnlPpal.Controls.Add(this.txtUsuario);
            this.pnlPpal.Controls.Add(this.label2);
            this.pnlPpal.Controls.Add(this.label1);
            this.pnlPpal.Controls.Add(this.txtPass);
            this.pnlPpal.Controls.Add(this.pnlLogo);
            this.pnlPpal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPpal.Location = new System.Drawing.Point(0, 0);
            this.pnlPpal.Name = "pnlPpal";
            this.pnlPpal.Size = new System.Drawing.Size(727, 339);
            this.pnlPpal.TabIndex = 0;
            // 
            // chbCicloLectivo
            // 
            this.chbCicloLectivo.AutoSize = true;
            this.chbCicloLectivo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.chbCicloLectivo.ForeColor = System.Drawing.Color.Silver;
            this.chbCicloLectivo.Location = new System.Drawing.Point(423, 205);
            this.chbCicloLectivo.Name = "chbCicloLectivo";
            this.chbCicloLectivo.Size = new System.Drawing.Size(127, 27);
            this.chbCicloLectivo.TabIndex = 7;
            this.chbCicloLectivo.Text = "Ciclo Lectivo";
            this.chbCicloLectivo.UseVisualStyleBackColor = true;
            this.chbCicloLectivo.CheckedChanged += new System.EventHandler(this.chbCicloLectivo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(274, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(274, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.pnlLogo.Controls.Add(this.lblIDDVS);
            this.pnlLogo.Controls.Add(this.pbxLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(232, 337);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblIDDVS
            // 
            this.lblIDDVS.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDDVS.ForeColor = System.Drawing.Color.Silver;
            this.lblIDDVS.Location = new System.Drawing.Point(11, 262);
            this.lblIDDVS.Name = "lblIDDVS";
            this.lblIDDVS.Size = new System.Drawing.Size(210, 54);
            this.lblIDDVS.TabIndex = 4;
            this.lblIDDVS.Text = "Instituto Dr. Dalmacio Vélez Sarsfield";
            this.lblIDDVS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::Capa.Presentacion.Properties.Resources.LogoTransparente;
            this.pbxLogo.Location = new System.Drawing.Point(44, 83);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(145, 132);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 1;
            this.pbxLogo.TabStop = false;
            // 
            // cbxCiclosLectivos
            // 
            this.cbxCiclosLectivos.Enabled = false;
            this.cbxCiclosLectivos.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.cbxCiclosLectivos.FormattingEnabled = true;
            this.cbxCiclosLectivos.Location = new System.Drawing.Point(556, 203);
            this.cbxCiclosLectivos.Name = "cbxCiclosLectivos";
            this.cbxCiclosLectivos.Size = new System.Drawing.Size(144, 31);
            this.cbxCiclosLectivos.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnSalir.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnSalir.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnSalir.BorderRadius = 10;
            this.btnSalir.BorderSize = 2;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.DisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnSalir.DisableBorderColor = System.Drawing.Color.DarkGray;
            this.btnSalir.DisableForeColor = System.Drawing.Color.DarkGray;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnSalir.Location = new System.Drawing.Point(494, 264);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(206, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnIniciar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnIniciar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnIniciar.BorderRadius = 10;
            this.btnIniciar.BorderSize = 2;
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.DisableBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnIniciar.DisableBorderColor = System.Drawing.Color.DarkGray;
            this.btnIniciar.DisableForeColor = System.Drawing.Color.DarkGray;
            this.btnIniciar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnIniciar.Location = new System.Drawing.Point(278, 264);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(206, 40);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtUsuario.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtUsuario.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtUsuario.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtUsuario.BorderSize = 1;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUsuario.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtUsuario.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtUsuario.Location = new System.Drawing.Point(278, 47);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.MaxLength = 32767;
            this.txtUsuario.Multiline = false;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Padding = new System.Windows.Forms.Padding(7);
            this.txtUsuario.PasswordChar = false;
            this.txtUsuario.ReadOnly = false;
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.Size = new System.Drawing.Size(422, 38);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsuario.Texts = "";
            this.txtUsuario.UnderLinedStyle = false;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtPass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtPass.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtPass.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtPass.BorderSize = 1;
            this.txtPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPass.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtPass.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtPass.Location = new System.Drawing.Point(278, 134);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.MaxLength = 32767;
            this.txtPass.Multiline = false;
            this.txtPass.Name = "txtPass";
            this.txtPass.Padding = new System.Windows.Forms.Padding(7);
            this.txtPass.PasswordChar = true;
            this.txtPass.ReadOnly = false;
            this.txtPass.SelectionLength = 0;
            this.txtPass.SelectionStart = 0;
            this.txtPass.Size = new System.Drawing.Size(422, 38);
            this.txtPass.TabIndex = 1;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPass.Texts = "";
            this.txtPass.UnderLinedStyle = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 339);
            this.Controls.Add(this.pnlPpal);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            this.pnlPpal.ResumeLayout(false);
            this.pnlPpal.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPpal;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox pbxLogo;
        private Controles.IDDVSTextbox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controles.IDDVSTextbox txtPass;
        private System.Windows.Forms.Label lblIDDVS;
        private Capa.Presentacion.Controles.IDDVSButton btnIniciar;
        private Capa.Presentacion.Controles.IDDVSButton btnSalir;
        private Controles.IDDVSCombobox cbxCiclosLectivos;
        private System.Windows.Forms.CheckBox chbCicloLectivo;
    }
}