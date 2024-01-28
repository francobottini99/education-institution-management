namespace Capa.Presentacion.Formularios.Gestión
{
    partial class frmGestionMatricula
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionMatricula));
            this.pbxX = new System.Windows.Forms.PictureBox();
            this.pnlCurso = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGrupo = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.txtCurso = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMatriculas = new System.Windows.Forms.Panel();
            this.dgvMatriculas = new Capa.Presentacion.Controles.IDDVSDataGrid();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuscarMatricula = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.pnlAlumnos = new System.Windows.Forms.Panel();
            this.dgvAlumnos = new Capa.Presentacion.Controles.IDDVSDataGrid();
            this.rdbSinMatricular = new Capa.Presentacion.Controles.IDDVSRadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarAlumno = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.rdbTodos = new Capa.Presentacion.Controles.IDDVSRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBuscarCurso = new Capa.Presentacion.Controles.IDDVSTextbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCursos = new Capa.Presentacion.Controles.IDDVSDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMatricular = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnGuardar = new Capa.Presentacion.Controles.IDDVSButton();
            this.btnCancelar = new Capa.Presentacion.Controles.IDDVSButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).BeginInit();
            this.pnlCurso.SuspendLayout();
            this.pnlMatriculas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculas)).BeginInit();
            this.panel5.SuspendLayout();
            this.pnlAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
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
            this.pbxX.TabIndex = 73;
            this.pbxX.TabStop = false;
            this.pbxX.Click += new System.EventHandler(this.pbxX_Click);
            // 
            // pnlCurso
            // 
            this.pnlCurso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCurso.Controls.Add(this.label3);
            this.pnlCurso.Controls.Add(this.txtGrupo);
            this.pnlCurso.Controls.Add(this.txtCurso);
            this.pnlCurso.Controls.Add(this.label6);
            this.pnlCurso.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCurso.Location = new System.Drawing.Point(0, 0);
            this.pnlCurso.Name = "pnlCurso";
            this.pnlCurso.Size = new System.Drawing.Size(668, 122);
            this.pnlCurso.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Grupo  Seleccionado";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtGrupo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtGrupo.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtGrupo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtGrupo.BorderSize = 1;
            this.txtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtGrupo.Enabled = false;
            this.txtGrupo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtGrupo.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtGrupo.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtGrupo.Location = new System.Drawing.Point(154, 68);
            this.txtGrupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrupo.MaxLength = 32767;
            this.txtGrupo.Multiline = false;
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Padding = new System.Windows.Forms.Padding(7);
            this.txtGrupo.PasswordChar = false;
            this.txtGrupo.ReadOnly = false;
            this.txtGrupo.SelectionLength = 0;
            this.txtGrupo.SelectionStart = 0;
            this.txtGrupo.Size = new System.Drawing.Size(502, 34);
            this.txtGrupo.TabIndex = 1;
            this.txtGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtGrupo.Texts = "";
            this.txtGrupo.UnderLinedStyle = false;
            // 
            // txtCurso
            // 
            this.txtCurso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtCurso.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtCurso.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtCurso.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtCurso.BorderSize = 1;
            this.txtCurso.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCurso.Enabled = false;
            this.txtCurso.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtCurso.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtCurso.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtCurso.Location = new System.Drawing.Point(154, 16);
            this.txtCurso.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurso.MaxLength = 32767;
            this.txtCurso.Multiline = false;
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Padding = new System.Windows.Forms.Padding(7);
            this.txtCurso.PasswordChar = false;
            this.txtCurso.ReadOnly = false;
            this.txtCurso.SelectionLength = 0;
            this.txtCurso.SelectionStart = 0;
            this.txtCurso.Size = new System.Drawing.Size(502, 34);
            this.txtCurso.TabIndex = 0;
            this.txtCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCurso.Texts = "";
            this.txtCurso.UnderLinedStyle = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Curso Seleccionado";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(666, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "MATRICULADOS AL CURSO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMatriculas
            // 
            this.pnlMatriculas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMatriculas.Controls.Add(this.dgvMatriculas);
            this.pnlMatriculas.Controls.Add(this.panel5);
            this.pnlMatriculas.Controls.Add(this.label1);
            this.pnlMatriculas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMatriculas.Location = new System.Drawing.Point(0, 360);
            this.pnlMatriculas.Name = "pnlMatriculas";
            this.pnlMatriculas.Size = new System.Drawing.Size(668, 239);
            this.pnlMatriculas.TabIndex = 2;
            // 
            // dgvMatriculas
            // 
            this.dgvMatriculas.AllowUserToAddRows = false;
            this.dgvMatriculas.AllowUserToDeleteRows = false;
            this.dgvMatriculas.AllowUserToResizeColumns = false;
            this.dgvMatriculas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatriculas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMatriculas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatriculas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.dgvMatriculas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMatriculas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMatriculas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatriculas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMatriculas.ColumnHeadersHeight = 30;
            this.dgvMatriculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMatriculas.DefaultAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatriculas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatriculas.EnableHeadersVisualStyles = false;
            this.dgvMatriculas.GridColor = System.Drawing.Color.DimGray;
            this.dgvMatriculas.Location = new System.Drawing.Point(0, 33);
            this.dgvMatriculas.MultiSelect = false;
            this.dgvMatriculas.Name = "dgvMatriculas";
            this.dgvMatriculas.ReadOnly = true;
            this.dgvMatriculas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatriculas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMatriculas.RowHeadersVisible = false;
            this.dgvMatriculas.RowHeadersWidth = 20;
            this.dgvMatriculas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatriculas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMatriculas.RowTemplate.Height = 25;
            this.dgvMatriculas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatriculas.Size = new System.Drawing.Size(666, 143);
            this.dgvMatriculas.StandardTab = true;
            this.dgvMatriculas.TabIndex = 3;
            this.dgvMatriculas.TabStop = false;
            this.dgvMatriculas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatriculas_CellClick);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.txtBuscarMatricula);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 176);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(666, 61);
            this.panel5.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 42;
            this.label5.Text = "Buscar";
            // 
            // txtBuscarMatricula
            // 
            this.txtBuscarMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarMatricula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtBuscarMatricula.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtBuscarMatricula.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtBuscarMatricula.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtBuscarMatricula.BorderSize = 1;
            this.txtBuscarMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarMatricula.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtBuscarMatricula.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtBuscarMatricula.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtBuscarMatricula.Location = new System.Drawing.Point(67, 14);
            this.txtBuscarMatricula.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarMatricula.MaxLength = 32767;
            this.txtBuscarMatricula.Multiline = false;
            this.txtBuscarMatricula.Name = "txtBuscarMatricula";
            this.txtBuscarMatricula.Padding = new System.Windows.Forms.Padding(7);
            this.txtBuscarMatricula.PasswordChar = false;
            this.txtBuscarMatricula.ReadOnly = false;
            this.txtBuscarMatricula.SelectionLength = 0;
            this.txtBuscarMatricula.SelectionStart = 0;
            this.txtBuscarMatricula.Size = new System.Drawing.Size(587, 34);
            this.txtBuscarMatricula.TabIndex = 4;
            this.txtBuscarMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarMatricula.Texts = "";
            this.txtBuscarMatricula.UnderLinedStyle = false;
            this.txtBuscarMatricula._TextChanged += new System.EventHandler(this.txtBuscarMatricula__TextChanged);
            // 
            // pnlAlumnos
            // 
            this.pnlAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlumnos.Controls.Add(this.dgvAlumnos);
            this.pnlAlumnos.Controls.Add(this.rdbSinMatricular);
            this.pnlAlumnos.Controls.Add(this.panel3);
            this.pnlAlumnos.Controls.Add(this.rdbTodos);
            this.pnlAlumnos.Controls.Add(this.label2);
            this.pnlAlumnos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlumnos.Location = new System.Drawing.Point(0, 120);
            this.pnlAlumnos.Name = "pnlAlumnos";
            this.pnlAlumnos.Size = new System.Drawing.Size(668, 240);
            this.pnlAlumnos.TabIndex = 1;
            // 
            // dgvAlumnos
            // 
            this.dgvAlumnos.AllowUserToAddRows = false;
            this.dgvAlumnos.AllowUserToDeleteRows = false;
            this.dgvAlumnos.AllowUserToResizeColumns = false;
            this.dgvAlumnos.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlumnos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlumnos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.dgvAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlumnos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvAlumnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAlumnos.ColumnHeadersHeight = 30;
            this.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAlumnos.DefaultAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnos.EnableHeadersVisualStyles = false;
            this.dgvAlumnos.GridColor = System.Drawing.Color.DimGray;
            this.dgvAlumnos.Location = new System.Drawing.Point(0, 33);
            this.dgvAlumnos.MultiSelect = false;
            this.dgvAlumnos.Name = "dgvAlumnos";
            this.dgvAlumnos.ReadOnly = true;
            this.dgvAlumnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlumnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAlumnos.RowHeadersVisible = false;
            this.dgvAlumnos.RowHeadersWidth = 20;
            this.dgvAlumnos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlumnos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAlumnos.RowTemplate.Height = 25;
            this.dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnos.Size = new System.Drawing.Size(666, 144);
            this.dgvAlumnos.StandardTab = true;
            this.dgvAlumnos.TabIndex = 2;
            this.dgvAlumnos.TabStop = false;
            this.dgvAlumnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnos_CellClick);
            // 
            // rdbSinMatricular
            // 
            this.rdbSinMatricular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbSinMatricular.AutoSize = true;
            this.rdbSinMatricular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.rdbSinMatricular.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.rdbSinMatricular.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.rdbSinMatricular.DisableColor = System.Drawing.Color.Silver;
            this.rdbSinMatricular.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.rdbSinMatricular.ForeColor = System.Drawing.Color.White;
            this.rdbSinMatricular.Location = new System.Drawing.Point(531, 5);
            this.rdbSinMatricular.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbSinMatricular.Name = "rdbSinMatricular";
            this.rdbSinMatricular.Size = new System.Drawing.Size(124, 23);
            this.rdbSinMatricular.TabIndex = 1;
            this.rdbSinMatricular.Text = "Sin Matricular";
            this.rdbSinMatricular.UnChekedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.rdbSinMatricular.UseVisualStyleBackColor = false;
            this.rdbSinMatricular.CheckedChanged += new System.EventHandler(this.rdbSinMatricular_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtBuscarAlumno);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 177);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(666, 61);
            this.panel3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "Buscar";
            // 
            // txtBuscarAlumno
            // 
            this.txtBuscarAlumno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarAlumno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtBuscarAlumno.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtBuscarAlumno.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtBuscarAlumno.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtBuscarAlumno.BorderSize = 1;
            this.txtBuscarAlumno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarAlumno.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtBuscarAlumno.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtBuscarAlumno.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtBuscarAlumno.Location = new System.Drawing.Point(67, 14);
            this.txtBuscarAlumno.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarAlumno.MaxLength = 32767;
            this.txtBuscarAlumno.Multiline = false;
            this.txtBuscarAlumno.Name = "txtBuscarAlumno";
            this.txtBuscarAlumno.Padding = new System.Windows.Forms.Padding(7);
            this.txtBuscarAlumno.PasswordChar = false;
            this.txtBuscarAlumno.ReadOnly = false;
            this.txtBuscarAlumno.SelectionLength = 0;
            this.txtBuscarAlumno.SelectionStart = 0;
            this.txtBuscarAlumno.Size = new System.Drawing.Size(587, 34);
            this.txtBuscarAlumno.TabIndex = 3;
            this.txtBuscarAlumno.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarAlumno.Texts = "";
            this.txtBuscarAlumno.UnderLinedStyle = false;
            this.txtBuscarAlumno._TextChanged += new System.EventHandler(this.txtBuscarAlumno__TextChanged);
            // 
            // rdbTodos
            // 
            this.rdbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.rdbTodos.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.rdbTodos.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.rdbTodos.DisableColor = System.Drawing.Color.Silver;
            this.rdbTodos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.rdbTodos.ForeColor = System.Drawing.Color.White;
            this.rdbTodos.Location = new System.Drawing.Point(458, 5);
            this.rdbTodos.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(67, 23);
            this.rdbTodos.TabIndex = 2;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UnChekedColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.rdbTodos.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(57)))), ((int)(((byte)(76)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(666, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "LISTADO DE ALUMNOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDatos
            // 
            this.pnlDatos.AutoScrollMargin = new System.Drawing.Size(15, 15);
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.pnlCurso);
            this.pnlDatos.Controls.Add(this.pnlAlumnos);
            this.pnlDatos.Controls.Add(this.pnlMatriculas);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatos.Location = new System.Drawing.Point(431, 33);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(670, 601);
            this.pnlDatos.TabIndex = 69;
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
            this.lblEncabezado.TabIndex = 72;
            this.lblEncabezado.Text = "IDDVS - GESTION DE MATRICULAS";
            this.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label21.Text = "LISTA DE CURSOS";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.txtBuscarCurso);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 537);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(429, 62);
            this.panel4.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(16, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 18);
            this.label20.TabIndex = 40;
            this.label20.Text = "Buscar";
            // 
            // txtBuscarCurso
            // 
            this.txtBuscarCurso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.txtBuscarCurso.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.txtBuscarCurso.BorderColorDisabled = System.Drawing.Color.Silver;
            this.txtBuscarCurso.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtBuscarCurso.BorderSize = 1;
            this.txtBuscarCurso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscarCurso.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtBuscarCurso.ForeColorDisabled = System.Drawing.Color.Gray;
            this.txtBuscarCurso.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.txtBuscarCurso.Location = new System.Drawing.Point(71, 14);
            this.txtBuscarCurso.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarCurso.MaxLength = 32767;
            this.txtBuscarCurso.Multiline = false;
            this.txtBuscarCurso.Name = "txtBuscarCurso";
            this.txtBuscarCurso.Padding = new System.Windows.Forms.Padding(7);
            this.txtBuscarCurso.PasswordChar = false;
            this.txtBuscarCurso.ReadOnly = false;
            this.txtBuscarCurso.SelectionLength = 0;
            this.txtBuscarCurso.SelectionStart = 0;
            this.txtBuscarCurso.Size = new System.Drawing.Size(341, 34);
            this.txtBuscarCurso.TabIndex = 7;
            this.txtBuscarCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBuscarCurso.Texts = "";
            this.txtBuscarCurso.UnderLinedStyle = false;
            this.txtBuscarCurso._TextChanged += new System.EventHandler(this.txtBuscarCurso__TextChanged);
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
            this.panel2.TabIndex = 4;
            // 
            // dgvCursos
            // 
            this.dgvCursos.AllowUserToAddRows = false;
            this.dgvCursos.AllowUserToDeleteRows = false;
            this.dgvCursos.AllowUserToResizeColumns = false;
            this.dgvCursos.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.dgvCursos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCursos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCursos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursos.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCursos.RowHeadersWidth = 20;
            this.dgvCursos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCursos.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvCursos.RowTemplate.Height = 25;
            this.dgvCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursos.Size = new System.Drawing.Size(429, 504);
            this.dgvCursos.StandardTab = true;
            this.dgvCursos.TabIndex = 8;
            this.dgvCursos.TabStop = false;
            this.dgvCursos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCursos_CellClick);
            this.dgvCursos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvCursos_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMatricular);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 634);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 68);
            this.panel1.TabIndex = 3;
            // 
            // btnMatricular
            // 
            this.btnMatricular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMatricular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.btnMatricular.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnMatricular.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnMatricular.BorderRadius = 10;
            this.btnMatricular.BorderSize = 2;
            this.btnMatricular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMatricular.DisableBackColor = System.Drawing.Color.Gainsboro;
            this.btnMatricular.DisableBorderColor = System.Drawing.Color.Silver;
            this.btnMatricular.DisableForeColor = System.Drawing.Color.Gray;
            this.btnMatricular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(214)))));
            this.btnMatricular.FlatAppearance.BorderSize = 0;
            this.btnMatricular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatricular.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnMatricular.ForeColor = System.Drawing.Color.White;
            this.btnMatricular.ForeFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(254)))), ((int)(((byte)(202)))));
            this.btnMatricular.Location = new System.Drawing.Point(715, 13);
            this.btnMatricular.Name = "btnMatricular";
            this.btnMatricular.Size = new System.Drawing.Size(120, 40);
            this.btnMatricular.TabIndex = 4;
            this.btnMatricular.Text = "Matricular";
            this.btnMatricular.UseVisualStyleBackColor = false;
            this.btnMatricular.Click += new System.EventHandler(this.btnMatricular_Click);
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
            this.btnGuardar.TabIndex = 5;
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
            this.btnCancelar.Location = new System.Drawing.Point(968, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmGestionMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1101, 702);
            this.Controls.Add(this.pbxX);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblEncabezado);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGestionMatricula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGestionMatricula";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestionMatricula_FormClosed);
            this.Shown += new System.EventHandler(this.frmGestionMatricula_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxX)).EndInit();
            this.pnlCurso.ResumeLayout(false);
            this.pnlCurso.PerformLayout();
            this.pnlMatriculas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculas)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlAlumnos.ResumeLayout(false);
            this.pnlAlumnos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxX;
        private Controles.IDDVSDataGrid dgvCursos;
        private Controles.IDDVSTextbox txtCurso;
        private System.Windows.Forms.Panel pnlCurso;
        private System.Windows.Forms.Label label3;
        private Controles.IDDVSTextbox txtGrupo;
        private System.Windows.Forms.Label label6;
        private Controles.IDDVSDataGrid dgvMatriculas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMatriculas;
        private Controles.IDDVSDataGrid dgvAlumnos;
        private System.Windows.Forms.Panel pnlAlumnos;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label20;
        private Controles.IDDVSTextbox txtBuscarCurso;
        private Controles.IDDVSButton btnMatricular;
        private Controles.IDDVSButton btnGuardar;
        private Controles.IDDVSButton btnCancelar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private Controles.IDDVSRadioButton rdbSinMatricular;
        private Controles.IDDVSRadioButton rdbTodos;
        private System.Windows.Forms.Label label4;
        private Controles.IDDVSTextbox txtBuscarAlumno;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private Controles.IDDVSTextbox txtBuscarMatricula;
    }
}