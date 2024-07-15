using Microsoft.EntityFrameworkCore;//usamos la clase EntityFrameworkCore
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestConSwagger.Models
{
    public class HeroContext: DbContext
    {
        public HeroContext (DbContextOptions<HeroContext> options) 
            : base(options)
        {

        }
        //Vamos a crear una tabla en la base de datos
        //a partir de la clase Hero y la voy a llamar HeroElisa
        public DbSet<Hero> Heroes { get; set; }

        public DbSet<Home> Home { get; set; }

    }
}
