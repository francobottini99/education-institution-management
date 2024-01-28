namespace Capa.Presentacion.Formularios.Altas
{
    partial class frmAltasMaterias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltasMaterias));
            this.pbxX = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtGrupo = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.btnBuscarGrupo = new Capa.Presentacion.Controles.IDDVSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurso = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.btnBuscarCurso = new Capa.Presentacion.Controles.IDDVSButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHoras = new Capa.Presentacion.Controles.IDDVSTextBoxNumerico();
            this.txtNombreMateria = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.label20 = new System.Windows.Forms.Label();
            this.dgvMaterias = new Capa.Presentacion.Controles.IDDVSDataGrid();
            this.label21 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtBuscar = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.btnEliminar = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnModificar = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnNuevo = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnGuardar = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnCancelar = new Capa.Presentacion.Controles.IDDVSButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxX
            // 
            this.pbxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.pbxX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxX.Image = global::Capa.Presentacion.Properties.Resources.cerrar;
            this.pbxX.Location = new System.Drawing.Point(1069, 4);
            this.pbxX.Name = "pbxX";
            this.pbxX.Size = new System.Drawing.Size(27, 24);
            this.pbxX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxX.TabIndex = 68;
            this.pbxX.TabStop = false;
            this.pbxX.Click += new System.EventHandler(this.pbxX_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoScrollMargin = new System.Drawing.Size(15, 15);
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtGrupo);
            this.panel3.Controls.Add(this.btnBuscarGrupo);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtCurso);
            this.panel3.Controls.Add(this.btnBuscarCurso);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtHoras);
            this.panel3.Controls.Add(this.txtNombreMateria);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(431, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(670, 601);
            this.panel3.TabIndex = 0;
            // 
            // txtGrupo
            // 
            this.txtGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtGrupo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtGrupo.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtGrupo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtGrupo.BorderSize = 1;
            this.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrupo.Enabled = false;
            this.txtGrupo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtGrupo.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtGrupo.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtGrupo.Location = new System.Drawing.Point(156, 174);
            this.txtGrupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrupo.MaxLength = 32767;
            this.txtGrupo.Multiline = false;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Padding = new System.Windows.Forms.Padding(7);
            this.txtGrupo.PasswordChar = false;
            this.txtGrupo.ReadOnly = false;
            this.txtGrupo.SelectionLength = 0;
            this.txtGrupo.SelectionStart = 0;
            this.txtGrupo.Size = new System.Drawing.Size(399, 34);
            this.txtGrupo.TabIndex = 4;
            this.txtGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtGrupo.Texts = "";
            this.txtGrupo.UnderLinedStyle = false;
            // 
            // btnBuscarGrupo
            // 
            this.btnBuscarGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnBuscarGrupo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnBuscarGrupo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnBuscarGrupo.BorderRadius = 10;
            this.btnBuscarGrupo.BorderSize = 2;
            this.btnBuscarGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarGrupo.DisableBackColor = System.Drawing.Color.Gainsboro;
            this.btnBuscarGrupo.DisableBorderColor = System.Drawing.Color.Silver;
            this.btnBuscarGrupo.DisableForeColor = System.Drawing.Color.Gray;
            this.btnBuscarGrupo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnBuscarGrupo.FlatAppearance.BorderSize = 0;
            this.btnBuscarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarGrupo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuscarGrupo.ForeColor = System.Drawing.Color.White;
            this.btnBuscarGrupo.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnBuscarGrupo.Location = new System.Drawing.Point(562, 174);
            this.btnBuscarGrupo.Name = "btnBuscarGrupo";
            this.btnBuscarGrupo.Size = new System.Drawing.Size(86, 34);
            this.btnBuscarGrupo.TabIndex = 5;
            this.btnBuscarGrupo.Text = "Buscar";
            this.btnBuscarGrupo.UseVisualStyleBackColor = false;
            this.btnBuscarGrupo.Click += new System.EventHandler(this.btnBuscarGrupo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Grupo";
            // 
            // txtCurso
            // 
            this.txtCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtCurso.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtCurso.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtCurso.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtCurso.BorderSize = 1;
            this.txtCurso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurso.Enabled = false;
            this.txtCurso.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtCurso.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtCurso.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtCurso.Location = new System.Drawing.Point(156, 122);
            this.txtCurso.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurso.MaxLength = 32767;
            this.txtCurso.Multiline = false;
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Padding = new System.Windows.Forms.Padding(7);
            this.txtCurso.PasswordChar = false;
            this.txtCurso.ReadOnly = false;
            this.txtCurso.SelectionLength = 0;
            this.txtCurso.SelectionStart = 0;
            this.txtCurso.Size = new System.Drawing.Size(399, 34);
            this.txtCurso.TabIndex = 2;
            this.txtCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCurso.Texts = "";
            this.txtCurso.UnderLinedStyle = false;
            // 
            // btnBuscarCurso
            // 
            this.btnBuscarCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnBuscarCurso.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnBuscarCurso.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnBuscarCurso.BorderRadius = 10;
            this.btnBuscarCurso.BorderSize = 2;
            this.btnBuscarCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCurso.DisableBackColor = System.Drawing.Color.Gainsboro;
            this.btnBuscarCurso.DisableBorderColor = System.Drawing.Color.Silver;
            this.btnBuscarCurso.DisableForeColor = System.Drawing.Color.Gray;
            this.btnBuscarCurso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnBuscarCurso.FlatAppearance.BorderSize = 0;
            this.btnBuscarCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCurso.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuscarCurso.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCurso.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnBuscarCurso.Location = new System.Drawing.Point(562, 122);
            this.btnBuscarCurso.Name = "btnBuscarCurso";
            this.btnBuscarCurso.Size = new System.Drawing.Size(86, 34);
            this.btnBuscarCurso.TabIndex = 3;
            this.btnBuscarCurso.Text = "Buscar";
            this.btnBuscarCurso.UseVisualStyleBackColor = false;
            this.btnBuscarCurso.Click += new System.EventHandler(this.btnBuscarCurso_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "Curso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(11, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nombre Materia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(11, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Horas Cátedra";
            // 
            // txtHoras
            // 
            this.txtHoras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtHoras.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtHoras.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtHoras.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtHoras.BorderSize = 1;
            this.txtHoras.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtHoras.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtHoras.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtHoras.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtHoras.Location = new System.Drawing.Point(156, 72);
            this.txtHoras.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoras.MaxLength = 32767;
            this.txtHoras.Multiline = false;
            this.txtHoras.Name = "txtHoras";
            this.txtHoras.Padding = new System.Windows.Forms.Padding(7);
            this.txtHoras.PasswordChar = false;
            this.txtHoras.ReadOnly = false;
            this.txtHoras.SelectionLength = 0;
            this.txtHoras.SelectionStart = 0;
            this.txtHoras.Size = new System.Drawing.Size(149, 34);
            this.txtHoras.TabIndex = 1;
            this.txtHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoras.Texts = "";
            this.txtHoras.UnderLinedStyle = false;
            // 
            // txtNombreMateria
            // 
            this.txtNombreMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtNombreMateria.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtNombreMateria.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtNombreMateria.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtNombreMateria.BorderSize = 1;
            this.txtNombreMateria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreMateria.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtNombreMateria.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtNombreMateria.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtNombreMateria.Location = new System.Drawing.Point(156, 19);
            this.txtNombreMateria.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreMateria.MaxLength = 32767;
            this.txtNombreMateria.Multiline = false;
            this.txtNombreMateria.Name = "txtNombreMateria";
            this.txtNombreMateria.Padding = new System.Windows.Forms.Padding(7);
            this.txtNombreMateria.PasswordChar = false;
            this.txtNombreMateria.ReadOnly = false;
            this.txtNombreMateria.SelectionLength = 0;
            this.txtNombreMateria.SelectionStart = 0;
            this.txtNombreMateria.Size = new System.Drawing.Size(492, 34);
            this.txtNombreMateria.TabIndex = 0;
            this.txtNombreMateria.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNombreMateria.Texts = "";
            this.txtNombreMateria.UnderLinedStyle = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(16, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 18);
            this.label20.TabIndex = 40;
            this.label20.Text = "Buscar";
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.AllowUserToAddRows = false;
            this.dgvMaterias.AllowUserToDeleteRows = false;
            this.dgvMaterias.AllowUserToResizeColumns = false;
            this.dgvMaterias.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMaterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.dgvMaterias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaterias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMaterias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.DefaultAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterias.EnableHeadersVisualStyles = false;
            this.dgvMaterias.GridColor = System.Drawing.Color.DimGray;
            this.dgvMaterias.Location = new System.Drawing.Point(0, 33);
            this.dgvMaterias.MultiSelect = false;
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.ReadOnly = true;
            this.dgvMaterias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterias.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMaterias.RowHeadersWidth = 20;
            this.dgvMaterias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterias.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMaterias.RowTemplate.Height = 25;
            this.dgvMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterias.Size = new System.Drawing.Size(429, 504);
            this.dgvMaterias.TabIndex = 3;
            this.dgvMaterias.TabStop = false;
            this.dgvMaterias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterias_CellClick);
            this.dgvMaterias.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvMaterias_MouseUp);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.label21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(429, 33);
            this.label21.TabIndex = 2;
            this.label21.Text = "LISTA DE MATERIAS ACTIVAS";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvMaterias);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 601);
            this.panel2.TabIndex = 65;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.txtBuscar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 537);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(429, 62);
            this.panel4.TabIndex = 2;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtBuscar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtBuscar.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtBuscar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtBuscar.BorderSize = 1;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtBuscar.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtBuscar.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtBuscar.Location = new System.Drawing.Point(71, 14);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscar.MaxLength = 32767;
            this.txtBuscar.Multiline = false;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Padding = new System.Windows.Forms.Padding(7);
            this.txtBuscar.PasswordChar = false;
            this.txtBuscar.ReadOnly = false;
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.Size = new System.Drawing.Size(341, 34);
            this.txtBuscar.TabIndex = 11;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscar.Texts = "";
            this.txtBuscar.UnderLinedStyle = false;
            this.txtBuscar._TextChanged += new System.EventHandler(this.txtBuscar__TextChanged);
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.lblEncabezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEncabezado.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezado.ForeColor = System.Drawing.Color.White;
            this.lblEncabezado.Location = new System.Drawing.Point(0, 0);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(1101, 33);
            this.lblEncabezado.TabIndex = 66;
            this.lblEncabezado.Text = "IDDVS - ALTAS DE MATERIAS";
            this.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnEliminar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnEliminar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnEliminar.BorderRadius = 10;
            this.btnEliminar.BorderSize = 2;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.DisableBackColor = System.Drawing.Color.Gainsboro;
            this.btnEliminar.DisableBorderColor = System.Drawing.Color.Silver;
            this.btnEliminar.DisableForeColor = System.Drawing.Color.Gray;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnEliminar.Location = new System.Drawing.Point(715, 13);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 40);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnModificar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnModificar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnModificar.BorderRadius = 10;
            this.btnModificar.BorderSize = 2;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.DisableBackColor = System.Drawing.Color.Gainsboro;
            this.btnModificar.DisableBorderColor = System.Drawing.Color.Silver;
            this.btnModificar.DisableForeColor = System.Drawing.Color.Gray;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnModificar.Location = new System.Drawing.Point(589, 13);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 40);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnNuevo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnNuevo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnNuevo.BorderRadius = 10;
            this.btnNuevo.BorderSize = 2;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.DisableBackColor = System.Drawing.Color.Gainsboro;
            this.btnNuevo.DisableBorderColor = System.Drawing.Color.Silver;
            this.btnNuevo.DisableForeColor = System.Drawing.Color.Gray;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnNuevo.Location = new System.Drawing.Point(463, 13);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 40);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnGuardar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnGuardar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnGuardar.BorderRadius = 10;
            this.btnGuardar.BorderSize = 2;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.DisableBackColor = System.Drawing.Color.Gainsboro;
            this.btnGuardar.DisableBorderColor = System.Drawing.Color.Silver;
            this.btnGuardar.DisableForeColor = System.Drawing.Color.Gray;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnGuardar.Location = new System.Drawing.Point(841, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 40);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnCancelar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnCancelar.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnCancelar.BorderRadius = 10;
            this.btnCancelar.BorderSize = 2;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DisableBackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.DisableBorderColor = System.Drawing.Color.Silver;
            this.btnCancelar.DisableForeColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnCancelar.Location = new System.Drawing.Point(967, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 634);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 68);
            this.panel1.TabIndex = 1;
            // 
            // frmAltasMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 702);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pbxX);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblEncabezado);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAltasMaterias";
            this.ShowInTaskbar = false;
            this.Text = "frmAltasMaterias";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAltasMaterias_FormClosed);
            this.Shown += new System.EventHandler(this.frmAltasMaterias_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxX;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Controles.IDDVSTextBoxNumerico txtHoras;
        private Controles.IDDVSTextbox txtNombreMateria;
        private System.Windows.Forms.Label label20;
        private Controles.IDDVSDataGrid dgvMaterias;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private Controles.IDDVSTextbox txtBuscar;
        private System.Windows.Forms.Label lblEncabezado;
        private Controles.IDDVSButton btnEliminar;
        private Controles.IDDVSButton btnModificar;
        private Controles.IDDVSButton btnNuevo;
        private Controles.IDDVSButton btnGuardar;
        private Controles.IDDVSButton btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private Controles.IDDVSTextbox txtGrupo;
        private Controles.IDDVSButton btnBuscarGrupo;
        private System.Windows.Forms.Label label1;
        private Controles.IDDVSTextbox txtCurso;
        private Controles.IDDVSButton btnBuscarCurso;
        private System.Windows.Forms.Label label5;
    }
}