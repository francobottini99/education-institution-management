using Capa.Presentacion.Controles;
using Capa.Presentacion.Formularios;
using Capa.Presentacion.Formularios.Altas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(IDDVSSplashScreen.GetInstance());
        }

        public static void Scale(Form frm)
        {
            float ratioX = 1, ratioY = 1;

            frm.AutoScaleMode = AutoScaleMode.Dpi;

            foreach (Screen item in Screen.AllScreens)
            {
                if (item.WorkingArea.Contains(frm.Location))
                {
                    ratioX = item.WorkingArea.Width / 1600.0f;
                    ratioY = item.WorkingArea.Height / 900.0f;

                    break;
                }
            }

            frm.Scale(new SizeF(ratioX, ratioY));

            foreach (Control ctrl in frm.Controls)
                Scale(ctrl, ratioX, ratioY);
        }

        private static void Scale(Control ctrl, float ratioX, float ratioY)
        {
            if (ctrl.Controls.Count > 0)
            {
                foreach (Control item in ctrl.Controls)
                    Scale(item, ratioX, ratioY);
            }
            else
            {
                ctrl.Font = new Font(ctrl.Font.Name, ctrl.Font.SizeInPoints * ratioX * ratioY, ctrl.Font.Style);

                if (ctrl is IDDVSButton buton)
                    buton.BorderRadius = (int)Math.Round(buton.BorderRadius * ratioX * ratioY, 0);

                if (ctrl is IDDVSTextbox textbox)
                {
                    textbox.BorderSize = (int)Math.Round(textbox.BorderSize * ratioX * ratioY, 0);
                    textbox.Size = new Size((int)Math.Round(textbox.Width * ratioX * ratioY, 0), (int)Math.Round(textbox.Height * ratioX * ratioY, 0));
                }

                if (ctrl is IDDVSDataGrid dataGrid)
                {
                    dataGrid.ColumnHeadersHeight = (int)Math.Round(dataGrid.ColumnHeadersHeight * ratioX * ratioY, 0);
                    dataGrid.RowHeadersWidth = (int)Math.Round(dataGrid.RowHeadersWidth * ratioX * ratioY, 0);
                    dataGrid.AlternatingRowsDefaultCellStyle.Font = new Font(dataGrid.AlternatingRowsDefaultCellStyle.Font.Name, dataGrid.AlternatingRowsDefaultCellStyle.Font.SizeInPoints * ratioX * ratioY, dataGrid.AlternatingRowsDefaultCellStyle.Font.Style);
                    dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(dataGrid.ColumnHeadersDefaultCellStyle.Font.Name, dataGrid.ColumnHeadersDefaultCellStyle.Font.SizeInPoints * ratioX * ratioY, dataGrid.ColumnHeadersDefaultCellStyle.Font.Style);
                    dataGrid.RowHeadersDefaultCellStyle.Font = new Font(dataGrid.RowHeadersDefaultCellStyle.Font.Name, dataGrid.RowHeadersDefaultCellStyle.Font.SizeInPoints * ratioX * ratioY, dataGrid.RowHeadersDefaultCellStyle.Font.Style);
                    dataGrid.RowsDefaultCellStyle.Font = new Font(dataGrid.RowsDefaultCellStyle.Font.Name, dataGrid.RowsDefaultCellStyle.Font.SizeInPoints * ratioX * ratioY, dataGrid.RowsDefaultCellStyle.Font.Style);
                    dataGrid.RowTemplate.Height = (int)Math.Round(dataGrid.RowTemplate.Height * ratioX * ratioY, 0);
                }

            }
        }
    }
}
