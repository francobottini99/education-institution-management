using Capa.Negocio.Datos;
using Capa.Negocio.DTO;
using Capa.Negocio.Servicios;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Presentacion.Controles;
using Capa.Presentacion.Controles.Formularios_Auxiliares;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Capa.Presentacion.Formularios
{
    public partial class frmLogin : Form
    {
        private IServicioUsuario servicioUsuario;

        private static frmLogin instance;

        private static readonly object _lock = new object();

        public static frmLogin GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmLogin();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private frmLogin()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            servicioUsuario = new ServicioUsuario();
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                IDDVSLoadingBox.Show("INICIANDO SESION");

                Cache.Usuario = await servicioUsuario.IniciarSesion(txtUsuario.Text, txtPass.Text);
                Cache.CicloLectivo = IDDVSSplashScreen.GetInstance().CicloLectivoList.Single(x => x.Año == int.Parse(cbxCiclosLectivos.Text));

                this.Hide();      
                frmPPal.GetInstance().ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                IDDVSLoadingBox.Hide();
                IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                txtUsuario.Select();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            foreach(CicloLectivoDTO item in IDDVSSplashScreen.GetInstance().CicloLectivoList)
                cbxCiclosLectivos.Items.Add(item.Año);

            cbxCiclosLectivos.Text = IDDVSSplashScreen.GetInstance().CicloLectivoList.ToList().Last().Año.ToString();
        }

        private void chbCicloLectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCicloLectivo.Checked)
            {
                cbxCiclosLectivos.Enabled = true;

                cbxCiclosLectivos.Select();
            }
            else
            {
                cbxCiclosLectivos.Enabled = false;
                cbxCiclosLectivos.Text = IDDVSSplashScreen.GetInstance().CicloLectivoList.ToList().Last().Año.ToString();
            }
        }
    }
}
