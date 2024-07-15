using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsumoAPIJoseAFerreRic.ApiRest
{
    class ConexionApi
    {
        //Realizamos una petición HttpPOST a la url indicada, pasándole el objeto
        //que queremos añadir en la API y la autorización (si nos hiciera falta)
        public dynamic Post(string url, string json, string autorizacion = null)
        {
            try
            {
                //Especificamos la url de la API a la que vamos a conectarnos
                var client = new RestClient(url);
                //Indicamos que vamos a hacer un HttpPOST
                var request = new RestRequest(Method.POST); //VERSION DE RestSharp 106.15.0
                //Añadimos el texto de cabecera y nuestro objeto en formato json
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", json, ParameterType.RequestBody);

                //Si se requiriera algún tipo de autorización se hubiera recibido
                //como parámetro su valor y se le pasaría al request para que la petición
                //fuera exitosa               
                if (autorizacion != null)
                {
                    request.AddHeader("Authorization", autorizacion);
                }
                //Ejecutamos la petición HttpPOST
                var response = client.Execute(request);

                //Deserializamos el objeto recién enviado para comprobar
                //qué es lo que hemos mandado
                dynamic datos = JsonConvert.DeserializeObject(response.Content);

                return datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //Obtenemos todos los objetos de una API en un json
        public dynamic Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Credentials = CredentialCache.DefaultCredentials;
            //request.Proxy = null;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream myStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(myStream))
            {
                //Leemos los datos
                string datos = reader.ReadToEnd();
                //Deserializamos
                dynamic datosDeserializados = JsonConvert.DeserializeObject(datos);
                return datosDeserializados;
            }

        }
    }
}
