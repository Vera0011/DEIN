using EasyBase.src.code;
using EasyBase.src.code.auth;
using EasyBase.src.ui.windows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace EasyBase
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Login login = new Login();
            Main main = new Main();
            Database_Window database = new Database_Window();
            Export_Window export = new Export_Window();
            Manage_Window manage = new Manage_Window();
            User_Profile user_profile = new User_Profile();

            login.Visibility = Visibility.Hidden;
            main.Visibility = Visibility.Hidden;
            database.Visibility = Visibility.Hidden;
            export.Visibility = Visibility.Hidden;
            manage.Visibility = Visibility.Hidden;
            user_profile.Visibility = Visibility.Hidden;

            WindowDictionary.addWindow(login);
            WindowDictionary.addWindow(main);
            WindowDictionary.addWindow(database);
            WindowDictionary.addWindow(export);
            WindowDictionary.addWindow(manage);
            WindowDictionary.addWindow(user_profile);

            this.verify_auth_statusAsync();
            this.Deactivated += App_Close;
        }

        /* Shutdown the App when all Windows are closed*/
        private void App_Close(object sender, EventArgs e)
        {
            ArrayList list = WindowDictionary.getDictionary();
            int counter = 0;

            foreach (Window item in list)
            {
                if (item.Visibility == Visibility.Hidden) counter++;
            }

            if (list.Count == counter) this.Shutdown();
        }

        /* Checks if bearer roken exists and is still valid */
        public async void verify_auth_statusAsync()
        {
            try
            {
                string savedToken = GetCookie(new Uri(AppContext.BaseDirectory + "/tmp/"));
                bool status = false;

                if (!string.IsNullOrEmpty(savedToken)) status = await Internal_Auth.isSuccessfulAsync(savedToken);

                if (status)
                {
                    ((Login)WindowDictionary.getWindow(typeof(Login))).Visibility = Visibility.Hidden;
                    ((Main)WindowDictionary.getWindow(typeof(Main))).Visibility = Visibility.Visible;
                }
            }
            catch
            {
                ((Login)WindowDictionary.getWindow(typeof(Login))).Visibility = Visibility.Visible;
            }
        }
    }
}
