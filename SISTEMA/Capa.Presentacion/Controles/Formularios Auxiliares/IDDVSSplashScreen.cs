using Capa.Negocio.DTO;
using Capa.Negocio.Servicios;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Presentacion.Formularios;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public partial class IDDVSSplashScreen : Form
    {
        public IEnumerable<CicloLectivoDTO> CicloLectivoList { get; set; }

        int dir = 1;

        private bool stopAnim = false;
        private bool success = false;

        private static IDDVSSplashScreen instance;

        private static readonly object _lock = new object();

        public static IDDVSSplashScreen GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new IDDVSSplashScreen();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private IDDVSSplashScreen()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void RefreshProgressbar()
        {
            while (!stopAnim)
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

                Thread.Sleep(10);
            }   
        }

        private void IDDVSSplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private async void LoadCiclosLectivos()
        {
            try
            {
                IServicioCicloLectivo servicioCicloLectivo = new ServicioCicloLectivo();

                CicloLectivoList = await servicioCicloLectivo.ConsultarTodos();
            
                success = true;
            }
            catch (Exception ex)
            {
                IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
            }
            finally
            {
                stopAnim = true;
            }
        }

        private void IDDVSSplashScreen_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            var thread = new Thread(new ThreadStart(LoadCiclosLectivos));

            thread.Start();

            RefreshProgressbar();

            if (success)
            {
                this.Hide();
                frmLogin.GetInstance().ShowDialog();
                this.Close();
            }
            else
                Application.Exit();
        }
    }
}
