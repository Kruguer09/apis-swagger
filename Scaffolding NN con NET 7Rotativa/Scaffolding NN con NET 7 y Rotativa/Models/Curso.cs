using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Models
{
    public class Curso
    {
        //clave primaria
        public int Id { get; set; }
        public string Nombre { get; set; } 

        //propiedad navegacional
        public List<EstudianteCurso> EstudianteCursos { get; set; }

    }
}
