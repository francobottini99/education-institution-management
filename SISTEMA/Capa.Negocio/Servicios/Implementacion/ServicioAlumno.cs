using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using Capa.Datos.Repositorios;
using Capa.Datos.Repositorios.Implementaciones;
using Capa.Negocio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio.Servicios.Implementacion
{
    public class ServicioAlumno : ServicioGenerico<AlumnoDTO, Alumno>, IServicioAlumno
    {
        private readonly IRepositorioAlumno repositorioAlumno;
        private readonly IRepositorioIndividuo repositorioIndividuo;
        private readonly IRepositorioMatricula repositorioMatricula;

        public ServicioAlumno() : base(new RepositorioAlumno())
        {
            repositorioAlumno = (IRepositorioAlumno)ObtenerRepositorio();
            repositorioIndividuo = new RepositorioIndividuo();
            repositorioMatricula = new RepositorioMatricula();
        }

        public async override Task Eliminar(int ID)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                Alumno modeloAlumno = await repositorioAlumno.ConsultarPorID(ID);

                if(modeloAlumno == null)
                    throw new ArgumentException("No existe el alumno que esta intentando eliminar");

                try
                {
                    await repositorioAlumno.Eliminar(modeloAlumno.ID);
                    await repositorioIndividuo.Eliminar(modeloAlumno.Individuo.ID);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async override Task<AlumnoDTO> Modificar(AlumnoDTO dto)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                var verificar = await repositorioIndividuo.ConsultarPorDNI(dto.Individuo.DNI);

                if (verificar != null)
                    if (verificar.ID != dto.Individuo.ID)
                        throw new ArgumentException("El alumno ya existe");

                try
                {
                    var modeloIndividuo = await repositorioIndividuo.Modificar(mapeador.Map<Individuo>(dto.Individuo));
                    var modeloAlumno = mapeador.Map<Alumno>(dto);

                    modeloAlumno.Individuo = modeloIndividuo;

                    modeloAlumno = await repositorioAlumno.Modificar(modeloAlumno);

                    transaction.Commit();

                    return mapeador.Map<AlumnoDTO>(modeloAlumno);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async override Task<AlumnoDTO> Insertar(AlumnoDTO dto)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                var verificar = await repositorioIndividuo.ConsultarPorDNI(dto.Individuo.DNI);

                if (verificar != null)
                    throw new ArgumentException("El alumno ya existe");

                try
                {
                    var modeloIndividuo = await repositorioIndividuo.Insertar(mapeador.Map<Individuo>(dto.Individuo));
                    var modeloAlumno = mapeador.Map<Alumno>(dto);

                    modeloAlumno.Individuo = modeloIndividuo;

                    modeloAlumno = await repositorioAlumno.Insertar(modeloAlumno);

                    transaction.Commit();

                    return mapeador.Map<AlumnoDTO>(modeloAlumno);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<AlumnoDTO>> ConsultarActivos()
        {
            return mapeador.Map<IEnumerable<AlumnoDTO>>(await repositorioAlumno.ConsultarPorEstado("Activo"));
        }

        public async Task<IEnumerable<AlumnoDTO>> ConsultarActivosSinMatricular(int IDCicloLectivo)
        {
            using (var transaction = ContextoIDDVS.BeginTransaction())
            {
                IEnumerable<Matricula> matriculasActivas = await repositorioMatricula.ConsultarPorEstadoYCicloLectivo("Activa", IDCicloLectivo);
                List<Alumno> alumnosActivos = (List<Alumno>)await repositorioAlumno.ConsultarPorEstado("Activo");
                List<Alumno> alumnosSinMatricular = alumnosActivos;

                foreach (Matricula matricula in matriculasActivas)
                    if (alumnosActivos.Contains(matricula.Alumno))
                        alumnosSinMatricular.Remove(matricula.Alumno);

                return mapeador.Map<IEnumerable<AlumnoDTO>>(alumnosSinMatricular);
            }
        }

        public async Task<bool> ExisteAlumno(string DNI)
        {
            return (await repositorioIndividuo.ConsultarPorDNI(DNI)) != null;
        }
    }
}
