using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    /*
     * Clase relación 1:N Hospital - Medico
     * 
     * Entidad que representa un Medico
     */
    public class Medico
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Specialty { get; set; }

        //FK respecto a Hospital
        [Required]
        public long HospitalId { get; set; }

    }
}
