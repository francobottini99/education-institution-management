using Capa.Presentacion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Formularios
{
    public partial class IDDVSMsgBox : Form
    {
        public enum Buttons
        {
            OK,
            OK_CANCEL,
            YES_NO
        }

        public enum Icons
        {
            ALERT,
            INFO,
            OK,
            ERROR
        }

        private static IDDVSMsgBox instance;

        private static readonly object _lock = new object();

        private static IDDVSMsgBox GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new IDDVSMsgBox();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }
        
        public static DialogResult Show(string msg, Buttons botton, Icons icon, bool longMsg = false)
        {
            IDDVSMsgBox MsgBox = GetInstance();

            if (longMsg)
                MsgBox.lblMsg.MaximumSize = new Size(600, 800);
            else
                MsgBox.lblMsg.MaximumSize = new Size(400, 800);

            MsgBox.lblMsg.Text = msg;

            switch (botton)
            {
                case Buttons.OK:
                    MsgBox.btnCancelar.Visible = false;
                    MsgBox.btnAceptar.Text = "Ok";
                    break;
                case Buttons.OK_CANCEL:
                    MsgBox.btnCancelar.Visible = true;
                    MsgBox.btnCancelar.Text = "Cancelar";
                    MsgBox.btnAceptar.Text = "Ok";
                    break;
                case Buttons.YES_NO:
                    MsgBox.btnCancelar.Visible = true;
                    MsgBox.btnCancelar.Text = "No";
                    MsgBox.btnAceptar.Text = "Si";
                    break;
            }

            switch(icon)
            {
                case Icons.OK:
                    MsgBox.pbxImg.Image = Resources.IconoOk;
                    break;
                case Icons.INFO:
                    MsgBox.pbxImg.Image = Resources.IconoInformacion;
                    break;
                case Icons.ALERT:
                    MsgBox.pbxImg.Image = Resources.IconoAlerta;
                    break;
                case Icons.ERROR:
                    MsgBox.pbxImg.Image = Resources.IconoError;
                    break;
            }

            MsgBox.btnAceptar.Select();
          
            return MsgBox.ShowDialog();
        }

        private IDDVSMsgBox()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void IDDVSMsgBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }
    }
}
