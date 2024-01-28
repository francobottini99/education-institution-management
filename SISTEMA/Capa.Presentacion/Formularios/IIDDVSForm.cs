using System.Windows.Forms;

namespace Capa.Presentacion.Formularios
{
    public interface IIDDVSForm<form> where form : Form
    {
        form GetInstance();
    }
}
