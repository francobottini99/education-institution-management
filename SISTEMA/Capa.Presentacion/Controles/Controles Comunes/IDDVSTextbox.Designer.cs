namespace Capa.Presentacion.Controles
{
    partial class IDDVSTextbox
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtControl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtControl
            // 
            this.txtControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.txtControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtControl.ForeColor = System.Drawing.Color.White;
            this.txtControl.Location = new System.Drawing.Point(7, 7);
            this.txtControl.Name = "txtControl";
            this.txtControl.Size = new System.Drawing.Size(186, 17);
            this.txtControl.TabIndex = 0;
            this.txtControl.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            this.txtControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtControl_KeyPress);
            // 
            // IDDVSTextbox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.txtControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IDDVSTextbox";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(200, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtControl;
    }
}
