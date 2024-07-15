using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EuroScaffolding2.Models
{
    //ENTIDAD PRINCIPAL
    //RELACION 1:N con Cancion
    public class EdFestival
    {
        [Key]
        public int Identificador { get; set; }

        [Range(1956, 2022, ErrorMessage = "El año debe estar comprendido entre 1956 y 2022")]
        public int Anyo { get; set; }

        public string Ciudad { get; set; }

        //Propiedad navegacional
        public List<Cancion> Canciones { get; set; }
    }
}
