using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {

        }
        //Tabla de Médicos
        public DbSet<Medico> Medicos { get; set; }
        //Tabla de Hsopitales
        public DbSet<Hospital> Hospitals { get; set; }

    }
}

