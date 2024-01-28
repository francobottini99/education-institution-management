using AutoMapper;
using Capa.Datos.Datos;
using Capa.Datos.Modelos;
using Capa.Negocio.DTO;
using System.Linq;

namespace Capa.Negocio.Mapeo
{
    public class MapperConfig
    {
        private static MapperConfiguration _instance;
        private static readonly object _lock = new object();

        public static MapperConfiguration GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = MapperConfiguration();
                    }
                }
            }

            return _instance;
        }

        private static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Individuo, IndividuoDTO>();
                cfg.CreateMap<IndividuoDTO, Individuo>();

                cfg.CreateMap<Personal, PersonalDTO>();
                cfg.CreateMap<PersonalDTO, Personal>()
                    .AfterMap((dto, model) => model.Individuo = ContextoIDDVS.GetInstance().Individuo.SingleOrDefault(x => x.ID == dto.Individuo.ID));

                cfg.CreateMap<Alumno, AlumnoDTO>();
                cfg.CreateMap<AlumnoDTO, Alumno>()
                    .AfterMap((dto, model) => model.Individuo = ContextoIDDVS.GetInstance().Individuo.SingleOrDefault(x => x.ID == dto.Individuo.ID));

                cfg.CreateMap<CicloLectivo, CicloLectivoDTO>();
                cfg.CreateMap<CicloLectivoDTO, CicloLectivo>();

                cfg.CreateMap<Usuario, UsuarioDTO>();
                cfg.CreateMap<UsuarioDTO, Usuario>()
                    .AfterMap((dto, model) => model.PerfilUsuario = ContextoIDDVS.GetInstance().PerfilUsuario.SingleOrDefault(x => x.ID == dto.PerfilUsuario.ID));

                cfg.CreateMap<PerfilUsuario, PerfilUsuarioDTO>();
                cfg.CreateMap<PerfilUsuarioDTO, PerfilUsuario>();

                cfg.CreateMap<DetallePerfilUsuario, DetallePerfilUsuarioDTO>();
                cfg.CreateMap<DetallePerfilUsuarioDTO, DetallePerfilUsuario>()
                    .AfterMap((dto, model) => model.PerfilUsuario = ContextoIDDVS.GetInstance().PerfilUsuario.SingleOrDefault(x => x.ID == dto.PerfilUsuario.ID));

                cfg.CreateMap<Curso, CursoDTO>();
                cfg.CreateMap<CursoDTO, Curso>()
                    .AfterMap((dto, model) => model.CicloLectivo = ContextoIDDVS.GetInstance().CiclolLectivo.SingleOrDefault(x => x.ID == dto.CicloLectivo.ID));

                cfg.CreateMap<Grupo, GrupoDTO>();
                cfg.CreateMap<GrupoDTO, Grupo>()
                    .AfterMap((dto, model) =>
                    {
                        model.CicloLectivo = ContextoIDDVS.GetInstance().CiclolLectivo.SingleOrDefault(x => x.ID == dto.CicloLectivo.ID);
                        model.Curso = ContextoIDDVS.GetInstance().Curso.SingleOrDefault(x => x.ID == dto.Curso.ID);
                    });

                cfg.CreateMap<Materia, MateriaDTO>();
                cfg.CreateMap<MateriaDTO, Materia>()
                    .AfterMap((dto, model) =>
                    {
                        model.CicloLectivo = ContextoIDDVS.GetInstance().CiclolLectivo.SingleOrDefault(x => x.ID == dto.CicloLectivo.ID);
                        model.Curso = ContextoIDDVS.GetInstance().Curso.SingleOrDefault(x => x.ID == dto.Curso.ID);
                        model.Grupo = ContextoIDDVS.GetInstance().Grupo.SingleOrDefault(x => x.ID == dto.Grupo.ID);
                    });

                cfg.CreateMap<Matricula, MatriculaDTO>();
                cfg.CreateMap<MatriculaDTO, Matricula>()
                    .AfterMap((dto, model) =>
                    {
                        model.CicloLectivo = ContextoIDDVS.GetInstance().CiclolLectivo.SingleOrDefault(x => x.ID == dto.CicloLectivo.ID);
                        model.Curso = ContextoIDDVS.GetInstance().Curso.SingleOrDefault(x => x.ID == dto.Curso.ID);
                        model.Grupo = ContextoIDDVS.GetInstance().Grupo.SingleOrDefault(x => x.ID == dto.Grupo.ID);
                        model.Alumno = ContextoIDDVS.GetInstance().Alumno.SingleOrDefault(x => x.ID == dto.Alumno.ID);
                    });
            });
        }
    }
}
