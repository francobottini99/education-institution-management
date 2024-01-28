using Capa.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Presentacion.Controles.Formularios_Auxiliares.Importar
{
    public interface ITypeImport
    {       
        event EventHandler<int> BeforeImport;
        event EventHandler<int> ProgressChangedImport;
        event EventHandler<IEnumerable<IDTO>> AfterImport;

        event EventHandler<int> BeforeSave;
        event EventHandler<int> ProgressChangedSave;
        event EventHandler<IEnumerable<IDTO>> AfterSave;

        void Importar(string filePath, ref IDDVSDataGrid dgv);
        void Guardar(IEnumerable<IDTO> data, ref IDDVSDataGrid dgv);
        string MensajeDeAyuda();
        void Stop();
        void Wait();
    }
}