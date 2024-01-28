using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Formularios.Altas
{
    public partial class frmCargosDocentes : Form
    {
        private static frmCargosDocentes instance;

        private static readonly object _lock = new object();


        public static frmCargosDocentes GetInstance()
        {
            if (instance == null)
            {
                {
                    if (instance == null)
                    {
                        instance = new frmCargosDocentes();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }



        public frmCargosDocentes()
        {
            InitializeComponent();
        }
    }
}
