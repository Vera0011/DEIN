using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyBase.src.code.database
{
    public class API_Queries
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string baseURL = "http://internal-easybase.es";

        public API_Queries()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(baseURL);
        }

        public async Task<string> PostAsync(string path, string body)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(path, new StringContent(body, Encoding.UTF8, "application/json"));
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return "401";
        }

        public async Task<string> PostAsyncWithAuth(string path, string body, string bearer_token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token);

            try
            {
                HttpResponseMessage response = await client.PostAsync(path, new StringContent(body, Encoding.UTF8, "application/json"));
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return "401";
        }

        public async Task<string> getAsync(string path, string bearer_token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token);

            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return "401";
        }
    }
}
