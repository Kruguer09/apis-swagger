using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Models
{
    public class Instituto
    {
        //clave primaria
        public int Id { get; set; }
        public string Nombre { get; set; } 

        //propiedad navegacional que recoge una colección de estudiantes
        //de esta forma estamos indicando que la relación entre
        //Institutos y Estudiantes va a ser 1:N
        public List<Estudiante> Estudiantes { get; set; } 
    }
}
