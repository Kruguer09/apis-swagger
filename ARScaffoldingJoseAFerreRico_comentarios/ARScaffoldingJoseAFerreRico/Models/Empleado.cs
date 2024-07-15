using System.ComponentModel.DataAnnotations;

namespace ARScaffoldingJoseAFerreRico.Models
{
    public class Empleado
    {
        //Clave principal
        [Key]
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        //Clave foránea
        [Required]
        public int EmpresaId { get; set; }

    }
}
