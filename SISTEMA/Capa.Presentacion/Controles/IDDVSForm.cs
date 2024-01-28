using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public class IDDVSForm : Form
    {
        private static IDDVSForm instance;

        private static readonly object _lock = new object();

        public static IDDVSForm GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmPPal();
                }
            }

            return instance;
        }
    }
}
