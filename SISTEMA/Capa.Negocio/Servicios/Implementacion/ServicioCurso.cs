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
    public class ServicioCurso : ServicioGenerico<CursoDTO, Curso>, IServicioCurso
    {
        private readonly IRepositorioCurso repositorioCurso;
        private readonly IRepositorioGrupo repositorioGrupo;
        private readonly IRepositorioMateria repositorioMateria;

        public ServicioCurso() : base(new RepositorioCurso())
        {
            repositorioCurso = (IRepositorioCurso)ObtenerRepositorio();
            repositorioGrupo = new RepositorioGrupo();
            repositorioMateria = new RepositorioMateria();
        }

        public async Task<IEnumerable<CursoDTO>> ConsultarPorIDCicloLectivo(int IDCicloLectivo)
        {
            return mapeador.Map<IEnumerable<CursoDTO>>(await repositorioCurso.ConsultarPorIDCicloLectivo(IDCicloLectivo));
        }

        public async override Task Eliminar(int ID)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                IEnumerable<Materia> materiasAsociadas = await repositorioMateria.ConsultarPorIDCurso(ID);

                if (materiasAsociadas.Count() > 0)
                    throw new ApplicationException("El curso seleccionado se encuentra asociado a una o mas materias, no es posible eliminarlo");

                IEnumerable<Grupo> gruposAsociados = await repositorioGrupo.ConsultarPorIDCurso(ID);
                
                try
                {
                    foreach (Grupo item in gruposAsociados)
                        await repositorioGrupo.Eliminar(item.ID);

                    await repositorioCurso.Eliminar(ID);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<bool> ExistenGruposAsociadoAlCurso(int ID)
        {
            return (await repositorioGrupo.ConsultarPorIDCurso(ID)).Count() > 1;
        }

        public async override Task<CursoDTO> Insertar(CursoDTO dto)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                var verificar = await repositorioCurso.ConsultarPorNumeroDivisionYIDCicloLectivo(dto.Numero, dto.Division, dto.CicloLectivo.ID);

                if (verificar != null)
                    throw new ArgumentException("El curso ya existe");

                try
                {
                    var modeloCurso = await repositorioCurso.Insertar(mapeador.Map<Curso>(dto));
                    var modeloGrupo = new Grupo 
                    {
                        Nombre = "GENERAL",
                        CicloLectivo = modeloCurso.CicloLectivo,
                        Curso = modeloCurso
                    };

                    await repositorioGrupo.Insertar(modeloGrupo);

                    transaction.Commit();

                    return mapeador.Map<CursoDTO>(modeloCurso);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async override Task<CursoDTO> Modificar(CursoDTO dto)
        {
            var verificar = await repositorioCurso.ConsultarPorNumeroDivisionYIDCicloLectivo(dto.Numero, dto.Division, dto.CicloLectivo.ID);

            if (verificar != null)
                if (verificar.ID != dto.ID)
                    throw new ArgumentException("El curso ya existe");

            return await base.Modificar(dto);
        }
    }
}
