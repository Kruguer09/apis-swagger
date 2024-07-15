
using EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Context
{
    public class MyDbContext : DbContext
    {
        //Establecemos el motor de la base de datos
        //especificando su cadena de conexión
        //Implementación del constructor
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Con esto estamos utilizando ApiFluent y le estamos diciendo que la entidad
            //Estudiante curso va a tener una clave primaria compuesta por CursoId y EstudianteId
            modelBuilder.Entity<EstudianteCurso>().HasKey(x => new { x.CursoId, x.EstudianteId });
        }

        //creamos una tabla llamada Estudiantes
        //a partir de nuestra clase Estudiante
        public DbSet<Estudiante> Estudiantes { get; set; }

        //creamos una tabla llamada Direcciones
        //a partir de nuestra clase Direccion
        public DbSet<Direccion> Direcciones { get; set; }

        //creamos una tabla llamada Institutos
        //a partir de nuestra clase Instituto
        public DbSet<Instituto> Institutos { get; set; }

        //creamos una tabla llamada Cursos
        //a partir de nuestra clase Curso
        public DbSet<Curso> Cursos { get; set; }

        //creamos una tabla llamada EstudiantesCursos
        //a partir de nuestra clase EstudianteCurso
        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }
    }
}
