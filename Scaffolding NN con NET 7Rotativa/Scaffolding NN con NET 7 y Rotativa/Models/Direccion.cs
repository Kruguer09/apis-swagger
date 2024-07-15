using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Models
{
    public class Direccion
    {
        //clave primaria
        public int Id { get; set; }
        public string Calle { get; set; } 

        //clave foránea 
        public int EstudianteId { get; set; }

        //para que al crear una nueva dirección me salgan en el desplegable
        //todos los EstudianteId disponibles
        public Estudiante Estudiante { get; set; } 
    }
}
