using ARScaffoldingJoseAFerreRico.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARScaffoldingJoseAFerreRico.Context
{
    public class EmpresaContext : DbContext
    {
        //Constructor vacío
        public EmpresaContext(DbContextOptions<EmpresaContext>options) : base(options)
        {
        }
        //Tabla Empresas
        public DbSet<Empresa> Empresas { get; set; }
        //Tabla Empleados
        public DbSet<Empleado> Empleados { get; set; }


    }
}
