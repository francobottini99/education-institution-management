using Capa.Presentacion.Formularios;
using Capa.Presentacion.Utilidades;
using System;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public class IDDVSTextBoxNumerico : IDDVSTextbox
    {
        public IDDVSTextBoxNumerico()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            txtControl.KeyPress += txtControl_Keypress;
            txtControl.TextAlign = HorizontalAlignment.Right;
            txtControl.Validated += txtControl_Validated;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void txtControl_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!Tools.IsNumeric(e.KeyChar.ToString()) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtControl_Validated(object sender, EventArgs e)
        {
            if (txtControl.Text != "")
            {
                txtControl.Text = string.Format("{0:#,##0}", Convert.ToDouble(txtControl.Text));
            }
        }
    }
}
