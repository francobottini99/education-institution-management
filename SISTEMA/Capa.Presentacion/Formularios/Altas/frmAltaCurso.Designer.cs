namespace Capa.Presentacion.Formularios.Altas
{
    partial class frmAltaCurso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaCurso));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCursos = new Capa.Presentacion.Controles.IDDVSDataGrid();
            this.label21 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBuscar = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNombreCurso = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.cbxDivisionCurso = new Capa.Presentacion.Controles.IDDVSCombobox();
            this.cbxNumCurso = new Capa.Presentacion.Controles.IDDVSCombobox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEliminar = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnModificar = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnNuevo = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnGuardar = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnCancelar = new Capa.Presentacion.Controles.IDDVSButton();
            this.pbxX = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvCursos);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 601);
            this.panel2.TabIndex = 66;
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.AllowUserToResizeColumns = false;
            this.dgvCursos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.dgvCursos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCursos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCursos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.DefaultAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCursos.EnableHeadersVisualStyles = false;
            this.dgvCursos.GridColor = System.Drawing.Color.DimGray;
            this.dgvCursos.Location = new System.Drawing.Point(0, 33);
            this.dgvCursos.MultiSelect = false;
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.ReadOnly = true;
            this.dgvCursos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCursos.RowHeadersWidth = 20;
            this.dgvCursos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCursos.RowTemplate.Height = 25;
            this.dgvCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursos.Size = new System.Drawing.Size(429, 504);
            this.dgvCursos.TabIndex = 3;
            this.dgvCursos.TabStop = false;
            this.dgvCursos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCursos_CellClick);
            this.dgvCursos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvCursos_MouseUp);
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
            this.label21.Text = "LISTA DE CURSOS ACTIVOS";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.txtBuscar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 537);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(429, 62);
            this.panel4.TabIndex = 2;
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
            this.txtBuscar.TabIndex = 8;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscar.Texts = "";
            this.txtBuscar.UnderLinedStyle = false;
            this.txtBuscar._TextChanged += new System.EventHandler(this.txtBuscar__TextChanged);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoScrollMargin = new System.Drawing.Size(15, 15);
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtNombreCurso);
            this.panel3.Controls.Add(this.cbxDivisionCurso);
            this.panel3.Controls.Add(this.cbxNumCurso);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(431, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(670, 601);
            this.panel3.TabIndex = 0;
            // 
            // txtNombreCurso
            // 
            this.txtNombreCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtNombreCurso.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtNombreCurso.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtNombreCurso.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtNombreCurso.BorderSize = 1;
            this.txtNombreCurso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreCurso.Enabled = false;
            this.txtNombreCurso.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtNombreCurso.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtNombreCurso.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtNombreCurso.Location = new System.Drawing.Point(160, 104);
            this.txtNombreCurso.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreCurso.MaxLength = 32767;
            this.txtNombreCurso.Multiline = false;
            this.txtNombreCurso.Name = "txtNombreCurso";
            this.txtNombreCurso.Padding = new System.Windows.Forms.Padding(7);
            this.txtNombreCurso.PasswordChar = false;
            this.txtNombreCurso.ReadOnly = false;
            this.txtNombreCurso.SelectionLength = 0;
            this.txtNombreCurso.SelectionStart = 0;
            this.txtNombreCurso.Size = new System.Drawing.Size(488, 34);
            this.txtNombreCurso.TabIndex = 12;
            this.txtNombreCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNombreCurso.Texts = "";
            this.txtNombreCurso.UnderLinedStyle = false;
            // 
            // cbxDivisionCurso
            // 
            this.cbxDivisionCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.cbxDivisionCurso.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDivisionCurso.ForeColor = System.Drawing.Color.White;
            this.cbxDivisionCurso.FormattingEnabled = true;
            this.cbxDivisionCurso.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "UNICA"});
            this.cbxDivisionCurso.Location = new System.Drawing.Point(160, 61);
            this.cbxDivisionCurso.Name = "cbxDivisionCurso";
            this.cbxDivisionCurso.Size = new System.Drawing.Size(246, 29);
            this.cbxDivisionCurso.Sorted = true;
            this.cbxDivisionCurso.TabIndex = 1;
            // 
            // cbxNumCurso
            // 
            this.cbxNumCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.cbxNumCurso.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNumCurso.ForeColor = System.Drawing.Color.White;
            this.cbxNumCurso.FormattingEnabled = true;
            this.cbxNumCurso.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbxNumCurso.Location = new System.Drawing.Point(160, 15);
            this.cbxNumCurso.Name = "cbxNumCurso";
            this.cbxNumCurso.Size = new System.Drawing.Size(149, 29);
            this.cbxNumCurso.TabIndex = 0;
            this.cbxNumCurso.SelectedIndexChanged += new System.EventHandler(this.cbxNumCurso_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(29, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre del Curso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(29, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Número de Curso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(29, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "División del Curso";
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
            this.lblEncabezado.TabIndex = 64;
            this.lblEncabezado.Text = "IDDVS - ALTAS DE CURSOS";
            this.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnEliminar.TabIndex = 5;
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
            this.btnModificar.TabIndex = 4;
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
            this.btnNuevo.TabIndex = 3;
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
            this.btnGuardar.TabIndex = 6;
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
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.pbxX.TabIndex = 67;
            this.pbxX.TabStop = false;
            this.pbxX.Click += new System.EventHandler(this.pbxX_Click);
            // 
            // frmAltaCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1101, 702);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pbxX);
            this.Controls.Add(this.lblEncabezado);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAltaCurso";
            this.ShowInTaskbar = false;
            this.Text = "frmAltasProfesores";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAltaCurso_FormClosed);
            this.Shown += new System.EventHandler(this.frmAltaCurso_Shown);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Controles.IDDVSButton btnEliminar;
        private Controles.IDDVSButton btnModificar;
        private Controles.IDDVSButton btnNuevo;
        private Controles.IDDVSButton btnGuardar;
        private Controles.IDDVSCombobox cbxDivisionCurso;
        private Controles.IDDVSCombobox cbxNumCurso;
        private System.Windows.Forms.Panel panel2;
        private Controles.IDDVSDataGrid dgvCursos;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label20;
        private Controles.IDDVSTextbox txtBuscar;
        private System.Windows.Forms.PictureBox pbxX;
        private Controles.IDDVSButton btnCancelar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Panel panel1;
        private Controles.IDDVSTextbox txtNombreCurso;
    }
}