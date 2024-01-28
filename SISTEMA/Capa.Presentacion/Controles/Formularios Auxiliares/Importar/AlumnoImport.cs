using Capa.Negocio.DTO;
using Capa.Negocio.Servicios;
using Capa.Negocio.Servicios.Implementacion;
using Capa.Presentacion.Properties;
using Capa.Presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Capa.Presentacion.Controles.Formularios_Auxiliares.Importar
{
    public class AlumnoImport : Import
    {
        public override void Guardar(IEnumerable<IDTO> data, ref IDDVSDataGrid dgv)
        {
            this.dgv = dgv;

            IEnumerable<AlumnoDTO> registres = (IEnumerable<AlumnoDTO>)data;
            List<AlumnoDTO> saveRegisters = new List<AlumnoDTO>();
            IServicioAlumno servicio = new ServicioAlumno();

            OnBeforeSave(data.Count());

            stopToken = stopSource.Token;
            uiContext = SynchronizationContext.Current;

            workTask = Task.Run(async () =>
            {
                int i = 1;

                foreach (AlumnoDTO item in data)
                {
                    try
                    {
                        if (stopToken.IsCancellationRequested)
                            break;

                        saveRegisters.Add(await servicio.Insertar(item));
                    }
                    finally
                    {
                        uiContext.Post(delegate { OnProgressChangedSave(i++); }, null);
                    }
                }

                if (!stopToken.IsCancellationRequested)
                    uiContext.Post(delegate { OnAfterSave(saveRegisters); }, null);
                else
                    uiContext.Post(delegate { OnAfterSave(null); }, null);
            }, stopToken);
        }

        public override void Importar(string filePath, ref IDDVSDataGrid dgv)
        {
            this.dgv = dgv;

            DataTable data = ReadExcelTable(filePath, "TABLA ALUMNOS");
            IServicioAlumno servicio = new ServicioAlumno();
            List<AlumnoDTO> validRegisters = new List<AlumnoDTO>();

            OnBeforeImport(data.Rows.Count);

            AddButtonAndImageColumns();
            AddColumns(typeof(IndividuoDTO).GetProperties());
            AddColumns(typeof(AlumnoDTO).GetProperties());
            SetDefaultColumnsAutoSizeMode();

            stopToken = stopSource.Token;
            uiContext = SynchronizationContext.Current;

            workTask = Task.Factory.StartNew(async () =>
            {
                int i = 1;

                foreach (DataRow row in data.Rows)
                {
                    if (stopToken.IsCancellationRequested)
                        break;

                    AlumnoDTO item = new AlumnoDTO() { Individuo = new IndividuoDTO() };

                    foreach (PropertyInfo property in typeof(AlumnoDTO).GetProperties())
                        if (property.Name != "ID" && !typeof(IDTO).IsAssignableFrom(property.PropertyType))
                            SetPropertyValue(item, property, row[property.Name].ToString());

                    foreach (PropertyInfo property in typeof(IndividuoDTO).GetProperties())
                        if (property.Name != "ID" && property.Name != "FechaAlta" && !typeof(IDTO).IsAssignableFrom(property.PropertyType))
                            SetPropertyValue(item.Individuo, property, row[property.Name].ToString());

                    item.Individuo.FechaAlta = DateTime.Now.Date;
                    item.Individuo.DNI = item.Individuo.DNI.Replace(".", "").Trim();

                    Bitmap image = Resources.IconoOk;
                    bool valid = true;

                    if (!await servicio.ExisteAlumno(item.Individuo.DNI))
                    {
                        if (Tools.Validate(item.Individuo, out _) && Tools.Validate(item, out _))
                            validRegisters.Add(item);
                        else
                        {
                            image = Resources.IconoError;
                            valid = false;
                        }
                    }
                    else
                    {
                        image = Resources.IconoAlerta;
                        valid = false;
                    }

                    uiContext.Post(delegate { OnProgressChangedImport(i++); }, null);

                    DataGridAddRow(item, image, valid);
                }

                if(!stopToken.IsCancellationRequested)
                    uiContext.Post(delegate { OnAfterImport(validRegisters); }, null);
                else
                    uiContext.Post(delegate { OnAfterImport(null); }, null);
            }, stopToken);
        }

        public override string MensajeDeAyuda()
        {
            return "Requisitos para importar alumnos desde un archivo Excel:\n\n - El archivo debe contener una hoja con el nombre \"TABLA ALUMNOS\" " +
                   "donde se encuentren los registros a importar.\n\n - Los registros se deben disponer en formato de tabla en donde " +
                   "la primera fila representa el encabezado de las columnas.\n\n - La tabla debe contener como mínimo las siguientes colunas: < " +
                   "FechaAlta, FechaNacimiento, FechaIngreso, NumeroLegajo, Genero, Apellidos, Nombres, DNI, Direccion, Localidad, CP, Provincia, " +
                   "Pais, Nacionalidad, Telefonos, Mail, Web, TipoIngreso, Tutores, TelefonoTutor, MailTutor, DireccionTutor, ProvinciaTutor, " +
                   "CPTutor, Estado >. Si se omite alguna de estas columnas los registros no podrán ser importados.\n\n - El orden de disposición de las " +
                   "columnas es irrelevante y queda a elección del usuario.\n\n - Si la tabla contiene otras columnas además de las listadas, " +
                   "no se genera ningún conflicto, el sistema simplemente las ignora.\n\n - No es necesario completar todas las celdas de la tabla, " +
                   "si existen celdas en blanco el sistema igual completara el proceso de importación.\n\n - A la hora de guardar los " +
                   "registros en el sistema, los mismos deben contar con los datos de carácter obligatorio para un alumno, estos son: < " +
                   "FechaAlta, FechaNacimiento, FechaIngreso, NumeroLegajo, Genero, Apellidos, Nombres, DNI, Direccion, Localidad, CP, Provincia, " +
                   "Pais, Nacionalidad, Telefonos, TipoIngreso, Tutores, TelefonoTutor, DireccionTutor, ProvinciaTutor, " +
                   "CPTutor, Estado >.\n\n - Si en un registro se omite alguno de los datos obligatorios, se dibujará una cruz en la columna " +
                   "\"VALIDO\" de la tabla con los registros importados. Por otra parte, en el caso de que un registro ya exista dentro del sistema " +
                   "será señalizado con un símbolo de advertencia en dicha columna. Finalmente, si el registro es válido para ser ingresado al sistema," +
                   "se establece una tilde en la columna.";
        }

        protected override bool IsValidColumns(DataColumnCollection columns)
        {
            return base.IsValidColumns<AlumnoDTO>(columns) && base.IsValidColumns<IndividuoDTO>(columns);
        }

        private void DataGridAddRow(AlumnoDTO item, Bitmap image, bool valid)
        {
            dgv.BeginInvoke(new Action(() =>
            {
                dgv.Rows.Add(
                    "X",
                    image,
                    valid,
                    item.Individuo.FechaAlta != DateTime.MinValue ? item.Individuo.FechaAlta.ToString("dd/MM/yyyy") : "",
                    item.Individuo.FechaNacimiento != DateTime.MinValue ? item.Individuo.FechaNacimiento.ToString("dd/MM/yyyy") : "",
                    item.Individuo.FechaIngreso != DateTime.MinValue ? item.Individuo.FechaIngreso.ToString("dd/MM/yyyy") : "",
                    item.Individuo.NumeroLegajo ?? "",
                    item.Individuo.Genero ?? "",
                    item.Individuo.Apellidos ?? "",
                    item.Individuo.Nombres ?? "",
                    item.Individuo.DNI ?? "",
                    item.Individuo.Direccion ?? "",
                    item.Individuo.Localidad ?? "",
                    item.Individuo.CP ?? "",
                    item.Individuo.Provincia ?? "",
                    item.Individuo.Pais ?? "",
                    item.Individuo.Nacionalidad ?? "",
                    item.Individuo.Telefonos ?? "",
                    item.Individuo.Mail ?? "",
                    item.Individuo.Web ?? "",
                    item.TipoIngreso ?? "",
                    item.Tutores ?? "",
                    item.TelefonoTutor ?? "",
                    item.MailTutor ?? "",
                    item.DireccionTutor ?? "",
                    item.ProvinciaTutor ?? "",
                    item.CPTutor ?? "",
                    item.Estado ?? ""
                );
            }));
        }
    }
}
