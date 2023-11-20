using EasyBase.src.code.database;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EasyBase.src.ui.windows;

namespace EasyBase.src.code.auth
{
    class Internal_Auth
    {
        private string bearer_code;

        public Internal_Auth(string email, string password)
        {
            // TODO -> Credentials verificator
            string jsonBody = JsonConvert.SerializeObject(new { email = email, password = password});
            StringContent body = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            this.ExecuteAuth(body);
        }

        public void RememberAuth()
        {

        }

        private async void ExecuteAuth(StringContent body)
        {
            /* Verify if user exists -> DEACTIVATED FOR FURTHER UPDATES */
            //this.bearer_code = await API_Queries.post("/account/v1/register", body, new Str).token;
        }

        public bool isSuccessful()
        {
            /* Verify if user is logged in correctly and bearer token is valid -> DEACTIVATED FOR FURTHER UPDATES */
            return true;
        }
    }
}
