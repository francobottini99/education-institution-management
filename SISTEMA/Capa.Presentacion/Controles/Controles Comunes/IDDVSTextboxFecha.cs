using Capa.Presentacion.Formularios;
using Capa.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public class IDDVSTextboxFecha : IDDVSTextbox 
    {
        public IDDVSTextboxFecha()
        {
            txtControl.KeyPress += txtControl_Keypress;
            txtControl.TextChanged += txtControl_TextChange;
            txtControl.Validated += txtControl_Validated;

            txtControl.TextAlign = HorizontalAlignment.Right;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //txtControl.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void txtControl_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!Tools.IsNumeric(e.KeyChar.ToString()) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 47)
                e.Handled = true;
        }

        private void txtControl_TextChange(object sender, EventArgs e)
        {
            if (Enabled && txtControl.Text == "") 
            {
                txtControl.Text = DateTime.Now.ToString("dd/MM/yyyy");

                txtControl.SelectionLength = txtControl.Text.Length;
                txtControl.Select();
            }
        }

        private void txtControl_Validated(object sender, EventArgs e)
        {
            if (txtControl.Text != "")
            {
                if (!Tools.IsDate(txtControl.Text))
                {
                    IDDVSMsgBox.Show("Formato de fecha incorrecto.", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);

                    txtControl.Text = "";
                    txtControl.Select();
                }
                else
                    txtControl.Text = DateTime.Parse(txtControl.Text).ToString("dd/MM/yyyy");
            }    
        }
    }
}
