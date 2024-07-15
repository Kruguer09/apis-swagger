using System.ComponentModel.DataAnnotations.Schema;

namespace EFconASPyMVC.Models
{
    //Clase CentroDeportivoUsuario que surge de la relación N:N entre centros deportivos y usuarios
    [Table("CentroDeportivoUsiario")]
    public class CentroDeportivoUsuario
    {
        //Clave principal compuesta
        public string UsuarioDniUsuario { get; set; }
        public int CentroDeportivoId { get; set; }
        //Navegacionales
        public CentroDeportivo CentroDeportivo { get; set; }
        //Para mostrar el usuario
        public Usuario Usuario { get; set; }
    }
}
