using EFconASPyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFconASPyMVC.Context
{
    // Clase que representa el contexto de la base de datos
    public class MyContext : DbContext
    {
        //Establecemos el motor de la base de datos
        //especificando su cadena de conexión
        //Implementación del constructor
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Con esto estamos utilizando ApiFluent para indicar claves principales y propiedad navegacional 1:n 
            modelBuilder.Entity<CentroDeportivoUsuario>().HasKey(x => new { x.UsuarioDniUsuario, x.CentroDeportivoId });
            modelBuilder.Entity<Director>().HasKey(x => new { x.DniDirector });
            modelBuilder.Entity<Pista>().HasKey(x => new { x.PistaNombre });
            modelBuilder.Entity<CentroDeportivo>().HasMany(l => l.Pistas); //propiedad navegacional Pistas

        }
        //creamos una tabla llamada CentrosDeportivos
        //a partir de nuestra clase CentroDeportivo
        public DbSet<CentroDeportivo> CentrosDeportivos { get; set; }
        //creamos una tabla llamada Directores
        //a partir de nuestra clase Director
        public DbSet<Director> Directores { get; set; }

        //creamos una tabla llamada Pistas
        //a partir de nuestra clase Pista
        public DbSet<Pista> Pistas { get; set; }

        //creamos una tabla llamada Usuarios
        //a partir de nuestra clase Usuario
        public DbSet<Usuario> Usuarios { get; set; }

        //creamos una tabla llamada CentrosUsuarios
        //a partir de nuestra clase CentroDeportivoUsuario
        public DbSet<CentroDeportivoUsuario> CentrosUsuarios { get; set; }
    }
}
