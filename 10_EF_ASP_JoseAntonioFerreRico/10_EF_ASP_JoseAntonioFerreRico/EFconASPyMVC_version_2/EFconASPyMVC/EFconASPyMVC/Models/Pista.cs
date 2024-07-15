namespace EFconASPyMVC.Models
{
    //Clase Pista que tiene una relación 1:N con CentroDeportivo
    public class Pista
    {
        //Clave principal
        public string PistaNombre { get; set; }
        public int Aforo { get; set; }
        
        //Foránea de centro deportivo
        public int CentroDeportivoId { get; set; }
        //Para mostrar el centro deportivo
        CentroDeportivo CentroDeportivo { get; set; }

    }
}
