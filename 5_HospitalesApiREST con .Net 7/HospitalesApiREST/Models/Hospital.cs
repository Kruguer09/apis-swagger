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
     * Entidad que representa un Hospital, el cual puede tener uno o varios Médicos
     */
    public class Hospital
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public long Tphno { get; set; }

        //Propiedad navegacional
        public List<Medico> ?Medicos { get; set; }

    }
}
