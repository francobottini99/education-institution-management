using AutoMapper;
using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using Capa.Datos.Repositorios;
using Capa.Datos.Repositorios.Implementaciones;
using Capa.Negocio.DTO;
using Capa.Negocio.Mapeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios.Implementacion
{
    public class ServicioMatricula : IServicioMatricula
    {
        private readonly IMapper mapeador;
        private readonly IRepositorioMatricula repositorioMatricula;
        private readonly IRepositorioCierreMatricula repositorioCierreMatricula;

        public ServicioMatricula()
        {
            repositorioMatricula = new RepositorioMatricula();
            repositorioCierreMatricula = new RepositorioCierreMatricula();
            mapeador = MapperConfig.GetInstance().CreateMapper();
        }

        public async Task ActualizarMatriculas(IEnumerable<MatriculaDTO> matriculas, GrupoDTO grupo, DateTime fecha)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                if (matriculas.Count() > 0)
                {
                    foreach (MatriculaDTO item in matriculas)
                    {
                        if (item.Grupo.ID != grupo.ID)
                        {
                            transaction.Rollback();
                            throw new Exception("El listado de matriculas dado contiene matriculas de mas de un grupo !");
                        }

                        if (item.CicloLectivo.ID != grupo.CicloLectivo.ID)
                        {
                            transaction.Rollback();
                            throw new Exception("El listado de matriculas dado contiene matriculas de mas de un ciclo lectivo !");
                        }
                    }
                }

                IEnumerable<Matricula> matriculasActuales = await repositorioMatricula.ConsultarPorEstadoGrupoYCicloLectivo("Activa", grupo.ID, grupo.CicloLectivo.ID);

                try
                {
                    if (matriculas.Count() > 0)
                    {
                        foreach (MatriculaDTO item in matriculas)
                        {
                            Matricula matriculaNueva = mapeador.Map<Matricula>(item);
                            Matricula matriculaActual = await repositorioMatricula.ConsultarPorID(matriculaNueva.ID);

                            matriculaNueva.Fecha = fecha;
                            matriculaNueva.Estado = "Activa";

                            if (matriculaActual != null)
                            {
                                matriculasActuales = matriculasActuales.Where(x => x.ID != matriculaActual.ID);

                                if (false) //Verificar si la matricula contiene datos asociados
                                {
                                    matriculaActual.Estado = "Inactiva";
                                    matriculaNueva.ID = 0;

                                    await repositorioCierreMatricula.Insertar(new CierreMatricula()
                                    {
                                        Fecha = fecha,
                                        Detalle = matriculaNueva.Curso.Equals(matriculaActual.Curso) ? "CAMBIO DE GRUPO" : "CAMBIO DE CURSO",
                                        Observaciones = "-",
                                        Matricula = matriculaActual
                                    });

                                    await repositorioMatricula.Modificar(matriculaActual);
                                    await repositorioMatricula.Insertar(matriculaNueva);
                                }
                                else
                                {
                                    matriculaActual.Fecha = matriculaNueva.Fecha;
                                    matriculaActual.Numero = matriculaNueva.Numero;
                                    matriculaActual.Estado = matriculaNueva.Estado;
                                    matriculaActual.Alumno = matriculaNueva.Alumno;
                                    matriculaActual.Grupo = matriculaNueva.Grupo;
                                    matriculaActual.CicloLectivo = matriculaNueva.CicloLectivo;
                                    matriculaActual.Curso = matriculaNueva.Curso;

                                    await repositorioMatricula.Modificar(matriculaActual);
                                }
                            }
                            else
                            {
                                matriculaNueva.ID = 0;
                                await repositorioMatricula.Insertar(matriculaNueva);
                            }
                        }
                    }

                    foreach (Matricula matriculaActual in matriculasActuales)
                    {
                        matriculaActual.Estado = "Inactiva";

                        if (false) //Verificar si la matricula contiene datos asociados
                        {
                            await repositorioCierreMatricula.Insertar(new CierreMatricula()
                            {
                                Fecha = fecha,
                                Detalle = "DESMATRICULACION",
                                Observaciones = "-",
                                Matricula = matriculaActual
                            });

                            await repositorioMatricula.Modificar(matriculaActual);
                        }
                        else
                            await repositorioMatricula.Eliminar(matriculaActual.ID);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<MatriculaDTO> ConsultarActivaAlumno(int IDAlumno, int IDCicloLectivo)
        {
            return mapeador.Map<MatriculaDTO>((await repositorioMatricula.ConsultarPorEstadoAlumnoYCicloLectivo("Activa", IDAlumno, IDCicloLectivo)).FirstOrDefault());
        }

        public async Task<IEnumerable<MatriculaDTO>> ConsultarActivasGrupo(int IDGrupo, int IDCicloLectivo)
        {
            return mapeador.Map<IEnumerable<MatriculaDTO>>(await repositorioMatricula.ConsultarPorEstadoGrupoYCicloLectivo("Activa", IDGrupo, IDCicloLectivo));
        }

        public async Task<bool> ExistenCambios(IEnumerable<MatriculaDTO> matriculasNuevas, GrupoDTO grupo)
        {
            IEnumerable<Matricula> matriculasActuales = await repositorioMatricula.ConsultarPorEstadoGrupoYCicloLectivo("Activa", grupo.ID, grupo.CicloLectivo.ID);

            if (matriculasNuevas.Count() != matriculasActuales.Count())
                return true;

            foreach (MatriculaDTO item in matriculasNuevas)
            {
                Matricula matriculaNueva = mapeador.Map<Matricula>(item);

                bool change = true;

                foreach (Matricula matriculaActual in matriculasActuales)
                {
                    if (matriculaActual.Alumno.Equals(matriculaNueva.Alumno) && 
                        matriculaActual.Grupo.Equals(matriculaNueva.Grupo) && 
                        matriculaActual.CicloLectivo.Equals(matriculaNueva.CicloLectivo))
                    {
                        change = false;
                        break;
                    }
                }

                if (change)
                    return true;
            }

            return false;
        }
    }
}
