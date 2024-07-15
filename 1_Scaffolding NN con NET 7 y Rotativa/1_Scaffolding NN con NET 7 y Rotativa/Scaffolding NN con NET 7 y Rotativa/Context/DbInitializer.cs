
using EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Context
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated(); //este método nos crea automáticamente la base de datos sin necesidad de migraciones

            // Comprueba si hay algún instituto
            if (context.Institutos.Any())
            {
                return;   // BD ya ha sido inicializada
            }
            //Añado institutos
            var instis = new Instituto[]
            {
            new Instituto{Nombre="IES Trassierra"},
            new Instituto{Nombre="IES Gran Capitán"},
            new Instituto{Nombre="IES Fidiana"},
            new Instituto{Nombre="IES Luis de Góngora"},

            };
            foreach (Instituto i in instis)
            {
                context.Institutos.Add(i);
            }
            context.SaveChanges();


            //Añado estudiantes
            var students = new Estudiante[]
            {
            new Estudiante{Nombre="Carson",Edad=17,InstitutoId=1},
            new Estudiante{Nombre="Meredith",Edad=19,InstitutoId=1},
            new Estudiante{Nombre="Arturo",Edad=18,InstitutoId=4},
            new Estudiante{Nombre="Gytis",Edad=21,InstitutoId=3},
            new Estudiante{Nombre="Yan",Edad=22,InstitutoId=2},
            new Estudiante{Nombre="Peggy",Edad=19,InstitutoId=2},
            new Estudiante{Nombre="Laura",Edad=19,InstitutoId=3},
            new Estudiante{Nombre="Nino",Edad=23,InstitutoId=4}
            };
            

            foreach (Estudiante s in students)
            {
                context.Estudiantes.Add(s);
            }
            context.SaveChanges();

            //Añado direcciones
            var dires = new Direccion[]
            {
            new Direccion{Calle="Luna",EstudianteId=1},
            new Direccion{Calle="Sol",EstudianteId=2},
            new Direccion{Calle="Amor",EstudianteId=3},
            new Direccion{Calle="Laurel",EstudianteId=4},
            new Direccion{Calle="Algarrobo",EstudianteId=5},
            new Direccion{Calle="Estrella",EstudianteId=6},
            new Direccion{Calle="Diana",EstudianteId=7},
            new Direccion{Calle="Tres",EstudianteId=8},
            };


            foreach (Direccion d in dires)
            {
                context.Direcciones.Add(d);
            }
            context.SaveChanges();


            //Añado cursos
            var courses = new Curso[]
            {
            new Curso{Nombre="Matemáticas"},
            new Curso{Nombre="Lengua"},
            new Curso{Nombre="Inglés"},
            new Curso{Nombre="Informática"},
            new Curso{Nombre="Filosofía"},
            new Curso{Nombre="Religión"},
            new Curso{Nombre="Biología"}
            };
            foreach (Curso c in courses)
            {
                context.Cursos.Add(c);
            }
            context.SaveChanges();


            //Añado EstudianteCursos
            var ec = new EstudianteCurso[]
            {
            new EstudianteCurso{EstudianteId=1, CursoId=1, Activo=true},
            new EstudianteCurso{EstudianteId=1, CursoId=2, Activo=true},
            new EstudianteCurso{EstudianteId=2, CursoId=1, Activo=true},
            new EstudianteCurso{EstudianteId=2, CursoId=3, Activo=true},
            new EstudianteCurso{EstudianteId=3, CursoId=3, Activo=true},
            new EstudianteCurso{EstudianteId=3, CursoId=5, Activo=true},
            new EstudianteCurso{EstudianteId=1, CursoId=7, Activo=true},
            new EstudianteCurso{EstudianteId=6, CursoId=7, Activo=true},
            new EstudianteCurso{EstudianteId=6, CursoId=6, Activo=true},
            new EstudianteCurso{EstudianteId=7, CursoId=6, Activo=true},
            new EstudianteCurso{EstudianteId=7, CursoId=4, Activo=true},
            new EstudianteCurso{EstudianteId=8, CursoId=4, Activo=false},
            new EstudianteCurso{EstudianteId=5, CursoId=4, Activo=false},
            new EstudianteCurso{EstudianteId=5, CursoId=2, Activo=false},
            new EstudianteCurso{EstudianteId=4, CursoId=6, Activo=false},
            new EstudianteCurso{EstudianteId=4, CursoId=4, Activo=false},
            new EstudianteCurso{EstudianteId=5, CursoId=3, Activo=false},
            new EstudianteCurso{EstudianteId=6, CursoId=1, Activo=false},
            };
            foreach (EstudianteCurso esC in ec)
            {
                context.EstudiantesCursos.Add(esC);
            }
            context.SaveChanges();
        }

    }

}
