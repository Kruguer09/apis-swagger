using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Models
{
    public class Estudiante
    {
        //Así EF sabrá que este campo será el primary key porque su nombre
        //es Id. También podría ser EstudianteId
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        //clave foránea con respecto a Institutos
        public int InstitutoId { get; set; }

        //propiedad navegacional que me va a permitir
        //estando en un estudiante acceder al registro
        //correspondiente de la tabla Direccion
        //es decir, así estoy indicando que la relación
        //entre Estudiantes y Direcciones va a ser 1:1 
        public Direccion Direccion { get; set; } 

        //propiedad navegacional
        public List<EstudianteCurso> EstudianteCursos { get; set; }

        //propiedad navegacional PARA DESPLEGABLE
        public Instituto Instituto { get; set; } 
    }
}
