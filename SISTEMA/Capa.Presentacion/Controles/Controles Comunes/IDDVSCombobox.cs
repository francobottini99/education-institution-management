using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public class IDDVSCombobox : ComboBox
    {
        public IDDVSCombobox()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (!DesignMode)
            {
                if (e.KeyChar == (char)Keys.Enter)
                    SendKeys.Send("{TAB}");

                e.Handled = true;
            }
        }
    }
}
