using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using Capa.Datos.Repositorios;
using Capa.Datos.Repositorios.Implementaciones;
using Capa.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios.Implementacion
{
    public class ServicioMateria : ServicioGenerico<MateriaDTO, Materia>, IServicioMateria
    {
        private readonly IRepositorioMateria repositorio;

        public ServicioMateria() : base(new RepositorioMateria())
        {
            repositorio = (IRepositorioMateria)ObtenerRepositorio();
        }

        public async Task<IEnumerable<MateriaDTO>> ConsultarPorIDCicloLectivo(int IDCicloLectivo)
        {
            return mapeador.Map<IEnumerable<MateriaDTO>>(await repositorio.ConsultarPorIDCicloLectivo(IDCicloLectivo));
        }

        public async override Task<MateriaDTO> Insertar(MateriaDTO dto)
        {
            var verificar = await repositorio.ConsultarPorNombreIDGrupoYIDCicloLectivo(dto.Nombre, dto.Grupo.ID, dto.CicloLectivo.ID);

            if (verificar != null)
                throw new ArgumentException("La materia ya existe");

            return await base.Insertar(dto);
        }

        public async override Task<MateriaDTO> Modificar(MateriaDTO dto)
        {
            var verificar = await repositorio.ConsultarPorNombreIDGrupoYIDCicloLectivo(dto.Nombre, dto.Grupo.ID, dto.CicloLectivo.ID);

            if (verificar != null)
                if(verificar.ID != dto.ID)
                    throw new ArgumentException("La materia ya existe");    

            return await base.Modificar(dto);
        }
    }
}
