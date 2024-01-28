using Capa.Negocio.Datos;
using Capa.Negocio.DTO;
using Capa.Negocio.Servicios;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Presentacion.Controles;
using Capa.Presentacion.Formularios.Altas;
using Capa.Presentacion.Formularios.Gestión;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Capa.Presentacion.Formularios
{
    public partial class frmPPal : Form
    {
        private static frmPPal instance;

        private static readonly object _lock = new object();

        public static frmPPal GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new frmPPal();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlBarraFrm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
            MaximizeHandler();
        }

        private void MaximizeHandler()
        {
            Screen formScreen = null;
            int bigIntersection = 0;

            foreach (Screen screen in Screen.AllScreens)
            {
                if (!pbxMaximizar.Visible)
                {
                    Rectangle intersection = Rectangle.Intersect(screen.WorkingArea, this.Bounds);

                    int areaIntersection = intersection.Width * intersection.Height;

                    if (areaIntersection > bigIntersection)
                    {
                        bigIntersection = areaIntersection;
                        formScreen = screen;
                    }
                }
                else
                {
                    if (new Rectangle(screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, 10).IntersectsWith(this.Bounds))
                    {
                        pbxMaximizar.Visible = false;
                        pbxRestablecer.Visible = true;
                        formScreen = screen;
                        break;
                    }
                }
            }

            if (formScreen != null)
            {
                this.Size = formScreen.WorkingArea.Size;
                this.Location = formScreen.WorkingArea.Location;
                this.MaximizedBounds = formScreen.WorkingArea;
            }
        }

        private frmPPal()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-AR");
            CultureInfo.DefaultThreadCurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            CultureInfo.DefaultThreadCurrentCulture.NumberFormat.CurrencyDecimalSeparator = ",";
            CultureInfo.DefaultThreadCurrentCulture.NumberFormat.CurrencyGroupSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture.NumberFormat.NumberDecimalSeparator = ",";
            CultureInfo.DefaultThreadCurrentCulture.NumberFormat.NumberGroupSeparator = ".";
        }

        private void frmPPal_Load(object sender, EventArgs e)
        {
            AcccessLoad();
            HideMenus();

            IDDVSLoadingBox.Hide();

            this.Show();

            MaximizeHandler();

            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToLongTimeString();
            
            lblUsuario.Text = Cache.Usuario.Apellidos + ", " + Cache.Usuario.Nombres;
            lblPerfil.Text = Cache.Usuario.PerfilUsuario.Nombre;
        }

        private void frmPPal_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private async void AcccessLoad()
        {
            IEnumerable<DetallePerfilUsuarioDTO> detale = await new ServicioPerfilUsuario().ConsultarDetallePerfil(Cache.Usuario.PerfilUsuario.ID);
            
            foreach (DetallePerfilUsuarioDTO item in detale)
            {
                switch (item.Menu)
                {
                    case "ALTAS PERSONAL":
                        btnAltasPersonal.Visible = true;
                        break;
                    case "ALTAS ALUMNOS":
                        btnAltasAlumnos.Visible = true;
                        break;
                    case "ALTAS CURSO":
                        btnAltasCurso.Visible = true;
                        break;
                    case "ALTAS GRUPO":
                        btnAltasGrupos.Visible = true;
                        break;
                    case "ALTAS MATERIA":
                        btnAltasMateria.Visible = true;
                        break;
                    case "ALTAS CARGOS DOCENTES":
                        btnAltasCargosDocentes.Visible = true;
                        break;
                    case "MATRICULA":
                        btnMatricula.Visible = true;
                        break;
                    case "PERFIL DE USUARIO":
                        btnSistemaPerfilUsuario.Visible = true;
                        break;
                    case "USUARIO":
                        btnSistemaUsuarios.Visible = true;
                        break;
                }
            }

            AcccessLoad(pnlMenuAltas, btnMenuAltas);
            AcccessLoad(pnlMenuSistema, btnMenuSistema);
            AcccessLoad(pnlMenuGestion, btnMenuGestion);
        }

        private void AcccessLoad(Panel panel, IDDVSButton button)
        {
            bool show = false;

            foreach (Control ctrl in panel.Controls)
                if (ctrl is IDDVSButton)
                    if (ctrl.Visible)
                        show = true;

            if(show)
                button.Visible = true;
        }

        private void HideMenus()
        {
            pnlMenuAltas.Visible = false;
            pnlMenuSistema.Visible = false;
            pnlMenuGestion.Visible = false;
        }

        private void bottonsColors()
        {
            btnMenuAltas.BackColor = Color.FromArgb(33, 50, 65);
            btnMenuSistema.BackColor = Color.FromArgb(33, 50, 65);
            pnlMenuGestion.BackColor = Color.FromArgb(33, 50, 65);
        }

        private void OpenForm(Form form)
        {
            if (form.Visible)
                return;

            if (pnlContenedor.Tag is Form actualFrm)
                actualFrm.Close();

            HideMenus();
            bottonsColors();

            if (pnlContenedor.Controls.Count > 0)
                pnlContenedor.Controls.RemoveAt(0);

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Parent = pnlContenedor;
            form.FormBorderStyle = FormBorderStyle.None;

            pnlContenedor.Controls.Add(form);
            pnlContenedor.Tag = form;

            form.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbxSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbxMaximizar_Click(object sender, EventArgs e)
        {
            pbxMaximizar.Visible = false;
            pbxRestablecer.Visible = true;

            MaximizeHandler();
        }

        private void pbxRestablecer_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1280, 768);
            this.CenterToScreen();

            pbxMaximizar.Visible = true;
            pbxRestablecer.Visible = false;
        }

        private void btnMenuAltas_Click(object sender, EventArgs e)
        {
            if (!pnlMenuAltas.Visible)
            {
                HideMenus();
                bottonsColors();

                pnlMenuAltas.Visible = true;
                btnMenuAltas.BackColor = Color.FromArgb(13, 79, 123);
            }
            else
            {
                HideMenus();
                bottonsColors();
            }
        }

        private void btnMenuSistema_Click(object sender, EventArgs e)
        {
            if (!pnlMenuSistema.Visible)
            {
                HideMenus();
                bottonsColors();

                pnlMenuSistema.Visible = true;
                btnMenuSistema.BackColor = Color.FromArgb(13, 79, 123);
            }
            else
            {
                HideMenus();
                bottonsColors();
            }
        }

        private void btnMenuGestion_Click_1(object sender, EventArgs e)
        {
            if (!pnlMenuGestion.Visible)
            {
                HideMenus();
                bottonsColors();

                pnlMenuGestion.Visible = true;
                pnlMenuGestion.BackColor = Color.FromArgb(13, 79, 123);
            }
            else
            {
                HideMenus();
                bottonsColors();
            }
        }

        private void btnSistemaPerfilUsuario_Click(object sender, EventArgs e)
        {
            OpenForm(frmPerfiles.GetInstance());
        }

        private void btnSistemaUsuarios_Click(object sender, EventArgs e)
        {
            OpenForm(frmUsuarios.GetInstance());
        }

        private void btnAltasPersonal_Click(object sender, EventArgs e)
        {
            OpenForm(frmAltasPersonal.GetInstance());
        }

        private void btnAltasAlumnos_Click(object sender, EventArgs e)
        {
            OpenForm(frmAltaAlumno.GetInstance());
        }

        private void btnAltasCurso_Click(object sender, EventArgs e)
        {
            OpenForm(frmAltaCurso.GetInstance());
        }

        private void btnAltasGrupos_Click(object sender, EventArgs e)
        {
            OpenForm(frmAltaGrupos.GetInstance());
        }

        private void btnAltasMateria_Click(object sender, EventArgs e)
        {
            OpenForm(frmAltasMaterias.GetInstance());
        }

        private void btnMatricula_Click(object sender, EventArgs e)
        {
            OpenForm(frmGestionMatricula.GetInstance());
        }

        private void btnAltasCargosDocentes_Click(object sender, EventArgs e)
        {
            OpenForm(frmCargosDocentes.GetInstance());
        }
    }
}
