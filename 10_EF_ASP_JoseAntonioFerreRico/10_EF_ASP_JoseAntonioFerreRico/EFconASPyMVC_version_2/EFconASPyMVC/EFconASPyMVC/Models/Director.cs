namespace EFconASPyMVC.Models
{
    //Clase Director que tiene una relación 1:1 con CentroDeportivo
    public class Director
    {
        //Clave primaria
        public string DniDirector { get; set; }
        public string Nombre { get; set; }
        public int Empleados { get; set; }
        //Foránea de CentroDeportivo
        public int CentroDeportivoId { get; set; }
        //Para mostrar el centro deportivo
        public CentroDeportivo CentroDeportivo {  get; set; }

    }
}
