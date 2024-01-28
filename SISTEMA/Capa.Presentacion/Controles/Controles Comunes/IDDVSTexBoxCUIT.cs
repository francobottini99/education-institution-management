using Capa.Presentacion.Formularios;
using Capa.Presentacion.Utilidades;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public class IDDVSTexBoxCUIT : IDDVSTextbox  
    {
        public IDDVSTexBoxCUIT()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            txtControl.Validated += txtControl_Validated;
            txtControl.KeyPress += TxtControl_KeyPress;
        }

        private void TxtControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)
            {
                if (!Tools.IsNumeric(e.KeyChar.ToString()) || txtControl.Text.Length == 13)
                {
                    e.Handled = true;
                    return;
                }

                if (txtControl.Text.Length == 2 || txtControl.Text.Length == 11)
                {
                    txtControl.Text += "-";
                    txtControl.SelectionStart = txtControl.Text.Length;
                }
            }
            else
            {
                if (txtControl.Text.Length == 4 || txtControl.Text.Length == 13)
                {
                    txtControl.Text = txtControl.Text.Substring(0, txtControl.Text.Length - 1);
                    txtControl.SelectionStart = txtControl.Text.Length;
                }
            }
        }

        private void txtControl_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtControl.Text))
                return;

            Regex regex = new Regex(@"^\d{2}-\d{8}-\d{1}$");

            if (!regex.IsMatch(txtControl.Text))
            {
                IDDVSMsgBox.Show("Número de CUIT incorrecto.", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);

                txtControl.SelectionLength = txtControl.Text.Length;
                txtControl.Select();
            }
            else
            {
                int total = 0;
                int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                char[] cuitArray = txtControl.Text.Replace("-", "").ToCharArray();

                for (int i = 0; i < mult.Length; i++)
                    total += int.Parse(cuitArray[i].ToString()) * mult[i];

                int mod = total % 11;
                int digito = mod == 0 ? 0 : mod == 1 ? 9 : 11 - mod;

                if (digito != int.Parse(cuitArray[10].ToString()))
                {
                    IDDVSMsgBox.Show("Número de CUIT incorrecto.", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);

                    txtControl.SelectionLength = txtControl.Text.Length;
                    txtControl.Select();
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // IDDVSTexBoxCUIT
            // 
            this.Name = "IDDVSTexBoxCUIT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
