using System.Data.Entity;
using Capa.Datos.Modelos;
using MySql.Data.EntityFramework;

namespace Capa.Datos.Datos
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ContextoIDDVS : DbContext
    {
        private static ContextoIDDVS _instance;

        private static readonly object _lock = new object();

        private ContextoIDDVS() : base("ContextoIDDVS") { }

        public static ContextoIDDVS GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ContextoIDDVS();
                    }
                }
            }

            return _instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Individuo>()
                .ToTable("INDIVIDUO")
                .HasKey(i => i.ID);

            modelBuilder.Entity<Personal>()
                .ToTable("PERSONAL")
                .HasKey(p => p.ID);

            modelBuilder.Entity<Alumno>()
                .ToTable("ALUMNO")
                .HasKey(a => a.ID);

            modelBuilder.Entity<CicloLectivo>()
                .ToTable("CICLOS_LECTIVOS")
                .HasKey(c => c.ID);

            modelBuilder.Entity<Usuario>()
                .ToTable("USUARIOS")
                .HasKey(u => u.ID);

            modelBuilder.Entity<PerfilUsuario>()
                .ToTable("PERFILES_USUARIO")
                .HasKey(p => p.ID);

            modelBuilder.Entity<DetallePerfilUsuario>()
                .ToTable("DETALLE_PERFILES_USUARIOS")
                .HasKey(d => d.ID);

            modelBuilder.Entity<Curso>()
                .ToTable("CURSO")
                .HasKey(c => c.ID);

            modelBuilder.Entity<Grupo>()
                .ToTable("GRUPOS")
                .HasKey(g => g.ID);

            modelBuilder.Entity<Materia>()
                .ToTable("MATERIAS")
                .HasKey(m => m.ID);

            modelBuilder.Entity<Matricula>()
                .ToTable("MATRICULAS")
                .HasKey(m => m.ID);

            modelBuilder.Entity<CierreMatricula>()
                .ToTable("CIERRE_MATRICULAS")
                .HasKey(m => m.ID);

            modelBuilder.Entity<Individuo>()
                .HasOptional(i => i.Personal)
                .WithRequired(p => p.Individuo)
                .Map(m => m.MapKey("INDIVIDUO_ID"));

            modelBuilder.Entity<Individuo>()
                .HasOptional(i => i.Alumno)
                .WithRequired(a => a.Individuo)
                .Map(m => m.MapKey("INDIVIDUO_ID"));

            modelBuilder.Entity<PerfilUsuario>()
                .HasOptional(p => p.Usuario)
                .WithRequired(u => u.PerfilUsuario)
                .Map(m => m.MapKey("PERFILES_USUARIO_ID"));

            modelBuilder.Entity<PerfilUsuario>()
                .HasMany(p => p.DetallePerfilUsuario)
                .WithRequired(m => m.PerfilUsuario)
                .Map(m => m.MapKey("PERFILES_USUARIO_ID"));

            modelBuilder.Entity<CicloLectivo>()
                .HasMany(c => c.Cursos)
                .WithRequired(c => c.CicloLectivo)
                .Map(m => m.MapKey("CICLOS_LECTIVOS_ID"));

            modelBuilder.Entity<CicloLectivo>()
                .HasMany(g => g.Grupos)
                .WithRequired(c => c.CicloLectivo)
                .Map(m => m.MapKey("CICLOS_LECTIVOS_ID"));

            modelBuilder.Entity<CicloLectivo>()
                .HasMany(m => m.Materias)
                .WithRequired(c => c.CicloLectivo)
                .Map(m => m.MapKey("CICLOS_LECTIVOS_ID"));

            modelBuilder.Entity<CicloLectivo>()
                .HasMany(c => c.Matriculas)
                .WithRequired(m => m.CicloLectivo)
                .Map(m => m.MapKey("CICLOS_LECTIVOS_ID"));

            modelBuilder.Entity<Curso>()
                .HasMany(g => g.Grupos)
                .WithRequired(c => c.Curso)
                .Map(m => m.MapKey("CURSO_ID"));

            modelBuilder.Entity<Curso>()
                .HasMany(m => m.Materias)
                .WithRequired(c => c.Curso)
                .Map(m => m.MapKey("CURSO_ID"));

            modelBuilder.Entity<Curso>()
                .HasMany(c => c.Matriculas)
                .WithRequired(m => m.Curso)
                .Map(m => m.MapKey("CURSO_ID"));

            modelBuilder.Entity<Grupo>()
                .HasMany(g => g.Materias)
                .WithRequired(m => m.Grupo)
                .Map(m => m.MapKey("GRUPOS_ID"));

            modelBuilder.Entity<Grupo>()
                .HasMany(g => g.Matriculas)
                .WithRequired(m => m.Grupo)
                .Map(m => m.MapKey("GRUPOS_ID"));

            modelBuilder.Entity<Alumno>()
                .HasMany(a => a.Matriculas)
                .WithRequired(m => m.Alumno)
                .Map(m => m.MapKey("ALUMNO_ID"));

            modelBuilder.Entity<Matricula>()
                .HasMany(m => m.CierreMatriculas)
                .WithRequired(c => c.Matricula)
                .Map(m => m.MapKey("MATRICULAS_ID"));

            base.OnModelCreating(modelBuilder);
        }

        public static DbContextTransaction BeginTransaction()
        {
            return GetInstance().Database.BeginTransaction();
        }

        public DbSet<Individuo> Individuo { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<CicloLectivo> CiclolLectivo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<DetallePerfilUsuario> DetallePerfilUsuario { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<CierreMatricula> CierreMatricula { get; set; }
    }
}
