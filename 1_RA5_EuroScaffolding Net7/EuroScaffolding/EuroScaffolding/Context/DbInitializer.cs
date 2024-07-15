using EuroScaffolding2.Models;
using System.Linq;

namespace EuroScaffolding2.Context
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated(); //este método nos crea automáticamente la base de datos sin necesidad de migraciones

            // Comprueba si hay algún festival
            if (context.EdFestivales.Any())
            {
                return;   // BD ya ha sido inicializada
            }
            //Añado festivales
            var festis = new EdFestival[]
            {
            new EdFestival{Anyo=2022, Ciudad="Turín"},
            new EdFestival{Anyo=2021, Ciudad="Róterdam"},
            new EdFestival{Anyo=2019, Ciudad="Tel Aviv"},
            };
            foreach (EdFestival ed in festis)
            {
                context.EdFestivales.Add(ed);
            }
            context.SaveChanges();


            //Añado canciones
            var songs = new Cancion[]
            {
                new Cancion{Titulo="SloMo",EdFestivalId=1},
                new Cancion{Titulo="Show",EdFestivalId=1},
                new Cancion{Titulo="Paz",EdFestivalId=1},
                new Cancion{Titulo="Line",EdFestivalId=2},
                new Cancion{Titulo="Hi",EdFestivalId=2},
                new Cancion{Titulo="Bye",EdFestivalId=2},
                new Cancion{Titulo="Line x",EdFestivalId=3},
                new Cancion{Titulo="Hi mama",EdFestivalId=3},
                new Cancion{Titulo="Bye papa",EdFestivalId=3},
            };


            foreach (Cancion s in songs)
            {
                context.Canciones.Add(s);
            }
            context.SaveChanges();

            //Añado paises
            var countrys = new Pais[]
            {
            new Pais{Nombre="España",CancionIdentificador=1},
            new Pais{Nombre="España",CancionIdentificador=4},
            new Pais{Nombre="España",CancionIdentificador=7},

            new Pais{Nombre="Austria",CancionIdentificador=2},
            new Pais{Nombre="Austria",CancionIdentificador=5},
            new Pais{Nombre="Austria",CancionIdentificador=8},

            new Pais{Nombre="Chipre",CancionIdentificador=3},
            new Pais{Nombre="Chipre",CancionIdentificador=6},
            new Pais{Nombre="Chipre",CancionIdentificador=9},
            };


            foreach (Pais p in countrys)
            {
                context.Paises.Add(p);
            }
            context.SaveChanges();


        
        }

    }

}
