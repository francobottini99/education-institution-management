using Capa.Datos.Modelos;
using Capa.Datos.Repositorios;
using Capa.Datos.Repositorios.Implementaciones;
using Capa.Negocio.DTO;
using System;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios.Implementacion
{
    public class ServicioCicloLectivo : ServicioGenerico<CicloLectivoDTO, CicloLectivo>, IServicioCicloLectivo
    {
        private readonly IRepositorioCicloLectivo repositorio;

        public ServicioCicloLectivo() : base(new RepositorioCicloLectivo())
        {
            repositorio = (IRepositorioCicloLectivo)ObtenerRepositorio();
        }

        public async override Task<CicloLectivoDTO> Insertar(CicloLectivoDTO dto)
        {
            var verificar = await repositorio.ConsultarPorAño(dto.Año);

            if (verificar != null)
                throw new ArgumentException("El ciclo lectivo ya existe");

            return await base.Insertar(dto);
        }

        public async override Task<CicloLectivoDTO> Modificar(CicloLectivoDTO dto)
        {
            var verificar = await repositorio.ConsultarPorAño(dto.Año);

            if (verificar != null)
                if(verificar.ID != dto.ID)
                    throw new ArgumentException("El ciclo lectivo ya existe");

            return await base.Modificar(dto);
        }
    }
}
