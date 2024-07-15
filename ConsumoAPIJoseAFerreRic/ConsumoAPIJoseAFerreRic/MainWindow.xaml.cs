using ConsumoAPIJoseAFerreRic.ApiRest;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsumoAPIJoseAFerreRic.ApiRest;
using static ConsumoAPIJoseAFerreRic.ClasesJSON;

namespace ConsumoAPIJoseAFerreRic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConexionApi conexionApi = new ConexionApi();
        const string rutaAnterior = "anterior.png";
        const string rutaSiguiente = "siguiente.png";
        const string rutaUltimo = "ultimo.png";
        const string rutaPrimero = "primero.png";
        private int posicion = 0;
        public MainWindow()
        {
            InitializeComponent();
            imgAnterior.Source = CargaImg(rutaAnterior);
            imgSiguiente.Source = CargaImg(rutaSiguiente);
            imgUltimo.Source = CargaImg(rutaUltimo);
            imgPrimero.Source = CargaImg(rutaPrimero);
        }

        private ImageSource CargaImg(string ruta)
        {
            const string rutaImagenes = "..\\..\\..\\imagenes\\";
            ImageSource salida = (new ImageSourceConverter()).ConvertFromString(rutaImagenes + ruta) as ImageSource;
            return salida;
        }

        private void Primero_Click(object sender, RoutedEventArgs e)
        {
            posicion = 0;
            dynamic respuesta = conexionApi.Get("https://localhost:7297/api/Empleadoes");
            MuestraDatos(respuesta, posicion);

        }

        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            dynamic respuesta = conexionApi.Get("https://localhost:7297/api/Empleadoes");
            if (posicion == 0)
            {
                MessageBox.Show("No hay más registros");
                return;
            }else
            {
                posicion--;
            }
            MuestraDatos(respuesta, posicion);

        }

        private void Siguiente_Click(object sender, RoutedEventArgs e)
        {
            // Revisamos el tamaño del json para no pasarnos
            dynamic respuesta = conexionApi.Get("https://localhost:7297/api/Empleadoes");
            if (posicion == respuesta.Count - 1)
            {
                MessageBox.Show("No hay más registros");
                return;
            }
            posicion++;
            
            MuestraDatos(respuesta, posicion);

        }

        private void Ultimo_Click(object sender, RoutedEventArgs e)
        {
            dynamic respuesta = conexionApi.Get("https://localhost:7297/api/Empleadoes");
            posicion = respuesta.Count - 1;
            

            MuestraDatos(respuesta, posicion);
        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            //Obtengo todos los objetos ya deserializados del json
            dynamic respuesta = conexionApi.Get("https://localhost:7297/api/Empleadoes");
            MuestraDatos(respuesta,posicion);
            buttonPost.IsEnabled = false;
        }

        private void MuestraDatos(dynamic respuesta,int posicion)
        {
            txtDNI.Text = respuesta[posicion].dni.ToString();
            txtNombre.Text = respuesta[posicion].nombre.ToString();
            txtDirección.Text = respuesta[posicion].direccion.ToString();
            txtSexo.Text = respuesta[posicion].sexo.ToString();
            txtIDEmpresa.Text = respuesta[posicion].empresaId.ToString();
        }

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado { direccion = txtDirección.Text, dni = txtDNI.Text, empresaId = int.Parse(txtIDEmpresa.Text), nombre = txtNombre.Text, sexo = txtSexo.Text };  
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(empleado);
            dynamic respuesta = conexionApi.Post("https://localhost:7297/api/Empleadoes", json);
            MessageBox.Show(respuesta.ToString());
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            // Método para poner todos los campos a vacío
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtDirección.Text = "";
            txtSexo.Text = "";
            txtIDEmpresa.Text = "";
            buttonPost.IsEnabled = false;

        }

        private void Control_LostFocus(object sender, RoutedEventArgs e)
        {
            // Verificar si todos los controles están llenos
            if (!string.IsNullOrEmpty(txtDNI.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtDirección.Text) &&
                !string.IsNullOrEmpty(txtSexo.Text) &&
                !string.IsNullOrEmpty(txtIDEmpresa.Text))
            {
                // Habilitar el botón POST
                buttonPost.IsEnabled = true;
            }
        }
    }

}