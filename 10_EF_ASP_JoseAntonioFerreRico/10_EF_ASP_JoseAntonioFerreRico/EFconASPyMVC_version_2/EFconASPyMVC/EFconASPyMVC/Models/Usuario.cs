using System.ComponentModel.DataAnnotations;

namespace EFconASPyMVC.Models
{
    //Clase Usuario que tiene una relación N:N con CentroDeportivo
    public class Usuario
    {
        //Clave principal
        [Key]

        public string DniUsuario { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        //Navegacional N:N
        public List<CentroDeportivoUsuario> CentroDeportivoUsuarios { get; set; }
    }
}
