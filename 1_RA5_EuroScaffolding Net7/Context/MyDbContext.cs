using Microsoft.EntityFrameworkCore;//usamos la clase EntityFrameworkCore
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroScaffolding2.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //1:N
            modelBuilder.Entity<Cancion>()
                .HasOne(x => x.EdFestival)
                .WithMany(x => x.Canciones)
                .OnDelete(DeleteBehavior.Cascade);

            //1:1
            modelBuilder.Entity<Cancion>()
                .HasOne(x => x.Pais)
                .WithOne(x => x.Cancion)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Cancion> Canciones { get; set; }
       
        public DbSet<EdFestival> EdFestivales{ get; set; }

        public DbSet<Pais> Paises { get; set; }
    }
}
