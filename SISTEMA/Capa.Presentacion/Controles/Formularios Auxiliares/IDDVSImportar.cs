using Capa.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Capa.Presentacion.Formularios;
using Capa.Presentacion.Controles.Formularios_Auxiliares.Importar;
using Capa.Presentacion.Properties;
using System.Linq;
using System.Drawing;

namespace Capa.Presentacion.Controles.Formularios_Auxiliares
{
    public partial class IDDVSImportar : Form
    {
        public enum Data
        {
            ALUMNOS,
            PERSONAL
        }

        private static ITypeImport typeImport;

        private static IDDVSImportar instance;

        private static readonly object _lock = new object();

        private static IEnumerable<IDTO> resultList;

        private static IDDVSImportar GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new IDDVSImportar();
                        Program.Scale(instance);
                    }
                }
            }

            return instance;
        }

        private IDDVSImportar()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        public static IEnumerable<IDTO> Show(ITypeImport dataType)
        {
            typeImport = dataType;

            if (GetInstance().ShowDialog() == DialogResult.OK)
                return resultList;
            else
                return null;
        }

        private void IDDVSImportar_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void IDDVSImportar_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            typeImport.BeforeImport += TypeImport_BeforeImport;
            typeImport.ProgressChangedImport += TypeImport_ProgressChangedImport;
            typeImport.AfterImport += TypeImport_AfterImport;

            typeImport.BeforeSave += TypeImport_BeforeSave;
            typeImport.ProgressChangedSave += TypeImport_ProgressChangedSave;
            typeImport.AfterSave += TypeImport_AfterSave;

            btnCancelar.Enabled = true;
            btnGuardar.Enabled = false;
            btnInformacion.Enabled = true;
        }

        private void TypeImport_AfterSave(object sender, IEnumerable<IDTO> e)
        {
            if (e != null)
            {
                resultList = e;

                lblEstado.Text = "REGISTROS GUARDADOS CORRECTAMENTE";

                IDDVSMsgBox.Show("Se completo la operacion !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                ClearGUI();
        }

        private void TypeImport_ProgressChangedSave(object sender, int e)
        {
            pgbProgreso.Value = e;
        }

        private void TypeImport_BeforeSave(object sender, int e)
        {
            pgbProgreso.Maximum = e;
            pgbProgreso.Value = 0;

            lblEstado.Text = "GUARDANDO REGISTROS...";

            btnInformacion.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void TypeImport_BeforeImport(object sender, int e)
        {
            pgbProgreso.ShowMaximun = true;
            pgbProgreso.ShowValue = IDDVSProgressBar.TextPosition.Center;

            pgbProgreso.Maximum = e;
            pgbProgreso.Value = 0;

            dgvDatos.Rows.Clear();
            dgvDatos.Columns.Clear();

            lblEstado.Text = "IMPORTANDO REGISTROS...";

            btnInformacion.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void TypeImport_AfterImport(object sender, IEnumerable<IDTO> e)
        {
            if (e != null)
            {
                resultList = e;

                lblEstado.Text = "REGISTROS IMPORTADOS CORRECTAMENTE";

                btnInformacion.Enabled = true;
                btnGuardar.Enabled = true;

                IDDVSMsgBox.Show("Se completo la operacion !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.OK);
            }
            else
                ClearGUI();
        }

        private void TypeImport_ProgressChangedImport(object sender, int e)
        {
            pgbProgreso.Value = e;
        }

        private void ClearGUI()
        {
            pgbProgreso.ShowMaximun = false;
            pgbProgreso.ShowValue = IDDVSProgressBar.TextPosition.None;

            dgvDatos.Rows.Clear();
            dgvDatos.Columns.Clear();

            txtArchivo.Text = "";
            lblEstado.Text = "";

            btnGuardar.Enabled = false;
            btnInformacion.Enabled = true;
            btnCancelar.Enabled = true;

            resultList = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ofdArchivos.Title = "Arhivo EXCEL";

            ofdArchivos.Filter = "Excel 2.0 a 2023 |*.xlsx;*.xls";

            if (ofdArchivos.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(ofdArchivos.FileName))
                {
                    txtArchivo.Text = ofdArchivos.FileName;

                    try
                    {
                        typeImport.Importar(txtArchivo.Text, ref dgvDatos);
                    }
                    catch (Exception ex)
                    {
                        ClearGUI();

                        IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                    }
                }
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDatos.Columns.Count > 0)
            {
                if (e.ColumnIndex == dgvDatos.Columns["Button"].Index && e.RowIndex > -1)
                {
                    dgvDatos.Rows.Remove(dgvDatos.CurrentRow);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            resultList = null;

            typeImport.Stop();

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(resultList.Count() > 0)
            {
                DialogResult response = IDDVSMsgBox.Show("Seguro que deseas guardar los datos importados ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO); ;

                if (response == DialogResult.OK)
                {
                    bool invalidRows = false;

                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        if (!(bool)row.Cells["Valid"].Value)
                        {
                            invalidRows = true;
                            break;
                        }
                    }

                    if (invalidRows)
                    {
                        response = IDDVSMsgBox.Show("Algunos de los datos importados no son aptos para ser insertados en el sistema, deseas removerlos del listado y continuar ?", IDDVSMsgBox.Buttons.OK_CANCEL, IDDVSMsgBox.Icons.INFO);

                        if (response == DialogResult.OK)
                        {
                            for (int i = dgvDatos.Rows.Count - 1; i >= 0; i--)
                                if (!(bool)dgvDatos.Rows[i].Cells["Valid"].Value)
                                    dgvDatos.Rows.Remove(dgvDatos.Rows[i]);
                        }
                    }

                    if (response == DialogResult.OK)
                    {
                        try
                        {
                            typeImport.Guardar(resultList, ref dgvDatos);
                        }
                        catch (Exception ex)
                        {
                            ClearGUI();

                            IDDVSMsgBox.Show(ex.Message, IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ERROR);
                        }
                    }
                }
            }
            else
                IDDVSMsgBox.Show("Ninguno de los registros importados es valido para ser insertado en el sistema !", IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.ALERT);
        }

        private void btnInformacion_Click(object sender, EventArgs e)
        {
            IDDVSMsgBox.Show(typeImport.MensajeDeAyuda(), IDDVSMsgBox.Buttons.OK, IDDVSMsgBox.Icons.INFO, true);
        }
    }
}
