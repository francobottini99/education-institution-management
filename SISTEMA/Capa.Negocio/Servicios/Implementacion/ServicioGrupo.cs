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
    public class ServicioGrupo : ServicioGenerico<GrupoDTO, Grupo>, IServicioGrupo
    {
        private readonly IRepositorioGrupo repositorioGrupo;
        private readonly IRepositorioMateria repositorioMateria;
        private readonly IRepositorioCurso repositorioCurso;

        public ServicioGrupo() : base(new RepositorioGrupo())
        {
            repositorioGrupo = (IRepositorioGrupo)ObtenerRepositorio();
            repositorioMateria = new RepositorioMateria();
            repositorioCurso = new RepositorioCurso();
        }

        public async Task<IEnumerable<GrupoDTO>> ConsultarPorIDCicloLectivo(int IDCicloLectivo)
        {
            return mapeador.Map<IEnumerable<GrupoDTO>>(await repositorioGrupo.ConsultarPorIDCicloLectivo(IDCicloLectivo));
        }

        public async Task<IEnumerable<GrupoDTO>> ConsultarPorIDCurso(int IDCurso)
        {
            return mapeador.Map<IEnumerable<GrupoDTO>>(await repositorioGrupo.ConsultarPorIDCurso(IDCurso));
        }

        public async Task<bool> ExistenRegistrosAsociadosAlGrupo(int ID)
        {
            return (await repositorioMateria.ConsultarPorIDGrupo(ID)).Count() > 0;
        }

        public async override Task Eliminar(int ID)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                Grupo modeloGrupoActual = await repositorioGrupo.ConsultarPorID(ID);
                Grupo modeloGrupoGeneral = (await repositorioGrupo.ConsultarPorIDCurso(modeloGrupoActual.Curso.ID)).Single(x => x.Nombre == "GENERAL");
                
                IEnumerable<Materia> materiasAsociadas = await repositorioMateria.ConsultarPorIDGrupo(modeloGrupoActual.ID); 

                try
                {
                    foreach (Materia item in materiasAsociadas)
                    {
                        item.Grupo = modeloGrupoGeneral;
                        await repositorioMateria.Modificar(item);
                    }

                    await repositorioGrupo.Eliminar(modeloGrupoActual.ID);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async override Task<GrupoDTO> Insertar(GrupoDTO dto)
        {
            var verificar = await repositorioGrupo.ConsultarPorNombreIDCursoYIDCicloLectivo(dto.Nombre, dto.Curso.ID, dto.CicloLectivo.ID);

            if (verificar != null)
                throw new ArgumentException("El grupo ya existe");

            return await base.Insertar(dto);
        }

        public async override Task<GrupoDTO> Modificar(GrupoDTO dto)
        {
            var verificar = await repositorioGrupo.ConsultarPorNombreIDCursoYIDCicloLectivo(dto.Nombre, dto.Curso.ID, dto.CicloLectivo.ID);

            if (verificar != null)
                if (verificar.ID != dto.ID)
                    throw new ArgumentException("El grupo ya existe");

            return await base.Modificar(dto);
        }
    }
}
