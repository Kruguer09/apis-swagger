using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Models
{
    //Esta clase va a representar la RELACIÓN N:N
    public class EstudianteCurso
    {   
        //Estas 2 propiedades van a representar la CLAVE PRIMARIA
        //que, por tanto, va a ser compuesta
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }

        //si el ese estudiante está en ese curso este año
        public bool Activo { get; set; }

        //Propiedad navegacional
        public Estudiante Estudiante { get; set; } 

        //Propiedad navegacional
        public Curso Curso { get; set; }  

    }
}
