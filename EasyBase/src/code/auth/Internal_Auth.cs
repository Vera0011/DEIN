using EasyBase.src.code.database;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EasyBase.src.ui.windows;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Net.PeerToPeer;
using System.Runtime.InteropServices;
using System.Security;

namespace EasyBase.src.code.auth
{
    class Internal_Auth
    {
        private static readonly API_Queries queryHandler = new API_Queries();
        public Internal_Auth(string email, string password, bool? remember)
        {
            bool remember_sanitized = remember ?? false;
            string jsonBody = JsonConvert.SerializeObject(new { email = email, password = password });
            RegisterUser(jsonBody, remember_sanitized);
        }

        /* Add user remember token */
        private void RememberAuth(string type, string bearer_token)
        {
            /*if (type == "temporal")*/ Application.SetCookie(new Uri(AppContext.BaseDirectory + "/tmp/"), $"SessionToken={bearer_token}");
            /* Add token to Windows Credentials --> TODO*/
            /*else if (type == "definitive")
            {
                
            }*/
        }

        public static async Task<bool> isSuccessfulAsync(string bearer_token)
        {
            string auth_result = await queryHandler.getAsync("/account/v1/status_login", bearer_token);

            if (JsonConvert.DeserializeObject<Response>(auth_result).Code == 200) return true;
            return false;
        }

        private async void RegisterUser(string body, bool remember_sanitized)
        {
            string token = await queryHandler.PostAsync("/account/v1/register", body);
            Response res = new Response();

            try
            {
                res = JsonConvert.DeserializeObject<Response>(token);
            }
            catch (Exception) { MessageBox.Show("Error al autentificar: La API fue bloqueada o está caída"); }

            if (res.Code == 200)
            {
                if (remember_sanitized) this.RememberAuth("definitive", res.Token);
                else this.RememberAuth("temporal", res.Token);

                ((Login)WindowDictionary.getWindow(typeof(Login))).changeWindow();
            }
            else if (res.Code == 401)
            {
                MessageBox.Show("Invalid user or password");
                Console.WriteLine(res.Message);
            }
        }

        public static async void load_data(string body)
        {
            string data = await queryHandler.PostAsyncWithAuth("/database/v1/query", body, Application.GetCookie(new Uri(AppContext.BaseDirectory + "/tmp/")));
            Response res = JsonConvert.DeserializeObject<Response>(data);

            if (res.Code == 200)
            {
                Console.WriteLine(res);
            }
            else if (res.Code == 401)
            {
                Console.WriteLine(res.Message);
            }
        }
    }
    class Response
    {
        public int Code { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
