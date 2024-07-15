using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EuroScaffolding2.Models
{
    public class Pais
    {
        
        public string Nombre { get; set; }
       
        //Clave foránea con respecto a Cancion y clave a la vez
        [Key]
        public int CancionIdentificador { get; set; }

        public Cancion Cancion { get; set; }


    }
}
