using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EasyBase.src.code.database
{
    public static class API_Queries
    {
        private static readonly HttpClient client = new HttpClient();
        
        public static StringContent post(string path, object body, string header_auth)
        {
            return null;
        }

        public static StringContent get(string path, string header_auth)
        {
            return null;
        }
    }
}
