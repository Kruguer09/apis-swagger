using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ARScaffoldingJoseAFerreRico.Models
{
    public class Empresa
    {
        //Clave principal
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int NumeroEmpleados { get; set; }
        //Propiedad navegacional
        public List<Empleado>? empleados { get; set; }
    }
}
