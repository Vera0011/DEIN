using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

namespace EasyBase.src.code.database
{
    class API_Connection
    {
        static readonly HttpClient client = new HttpClient();

        public API_Connection()
        {
            string email = "vera_prueba";
            string password = "1234";

            this.getConnection();
        }

        private async void getConnection()
        {
            string apiUrl = "https://127.0.0.1:80/account/v1/login";

            // Datos que enviarás en el cuerpo de la solicitud (en formato JSON en este caso)
            string jsonData = "{\"email\": \"vera_prueba\", \"password\": \"1234\", \"api_key\": \"1234\"}";

            // Crear una instancia de HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                
            }
        }
    }
}
