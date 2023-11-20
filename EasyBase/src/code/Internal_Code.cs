using EasyBase.src.code.auth;
using EasyBase.src.ui.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBase.src.code
{
    internal class Internal_Code
    {
        private readonly Internal_Auth auth;
        public Internal_Code(string email, string password, bool? remember)
        {
            bool rememberCasted = remember ?? false;
            auth = new Internal_Auth(email, password);

            if (rememberCasted) auth.RememberAuth();

            if(auth.isSuccessful())
            {
                new Login().changeWindow();
            }
        }
    }
}
