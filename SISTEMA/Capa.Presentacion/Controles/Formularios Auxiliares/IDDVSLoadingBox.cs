using Capa.Presentacion.Formularios;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public partial class IDDVSLoadingBox : Form
    {
        int dir = 1;

        private static List<Form> disbaleForms = null;

        private static IDDVSLoadingBox instance;

        private static readonly object _lock = new object();

        private static IDDVSLoadingBox GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new IDDVSLoadingBox();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        public static void Show(string msg = "CARGANDO")
        {
            if (instance != null)
                return;

            Cursor.Current = Cursors.WaitCursor;

            IDDVSLoadingBox form = GetInstance();

            Task.Factory.StartNew(() => {
                form.tmrAnimation.Enabled = true;
                form.lblMsg.Text = msg;
                form.ShowDialog();
            });

            //DisableOpenForms();
        }

        public static new void Hide()
        {
            if (instance == null)
                return;

            Cursor.Current = Cursors.Default;

            IDDVSLoadingBox form = instance;

            form.BeginInvoke((Action)(() => {
                form.tmrAnimation.Enabled = false;
                form.Close();
            }));

            //EnableForms();
        }

        private static void DisableOpenForms()
        {
            if (disbaleForms == null)
                disbaleForms = new List<Form>();

            foreach (Form form in Application.OpenForms)
            { 
                if (!(form is IDDVSLoadingBox))
                { 
                    disbaleForms.Add(form);
                    ChangeControlEnable(form, false);     
                }
            }
        }

        private static void EnableForms()
        {
            if (disbaleForms == null)
                return;

            foreach (Form form in disbaleForms)
                ChangeControlEnable(form, true);

            disbaleForms.Clear();
        }

        private static void ChangeControlEnable(Control ctrl, bool enable)
        {
            if(ctrl.Controls.Count > 0)
            {
                foreach (Control item in ctrl.Controls)
                    ChangeControlEnable(item, enable);
            }
            else
            {
                if (ctrl is IDDVSButton || ctrl is IDDVSCombobox || ctrl is IDDVSTextbox || ctrl is IDDVSDataGrid)
                    ctrl.Enabled = enable;
            }
        }

        private IDDVSLoadingBox()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void tmrAnimation_Tick(object sender, EventArgs e)
        {
            if (dir == 1)
            {
                if (pgbLoad.Value < pgbLoad.Maximum)
                    pgbLoad.Value++;
                else
                    dir = -1;
            }
            else
            {
                if (pgbLoad.Value > pgbLoad.Minimum)
                    pgbLoad.Value--;
                else
                    dir = 1;
            }
        }

        private void IDDVSLoadingBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }
    }
}
