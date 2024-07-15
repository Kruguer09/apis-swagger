using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EuroScaffolding2.Models
{
    //ENTIDAD PPAL
    //RELACION 1:1 con Grupo
    public class Cancion
    {
        
        [Key]
        public int Identificador { get; set; }
        public string Titulo { get; set; }

        //Clave foránea con respecto a EdFestival
        public int EdFestivalId { get; set; }

        public Pais Pais { get; set; }

        public EdFestival EdFestival { get; set; }

        
    }
}
