using EasyBase.src.code;
using EasyBase.src.code.auth;
using EasyBase.src.code.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasyBase.src.ui.windows
{
    /// <summary>
    /// Lógica de interacción para LOGIN.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            WindowDictionary.addWindow(this);
        }

        public void Validate_Credentials(object sender, RoutedEventArgs e)
        {
            /* VALIDATION OF EMAIL AND PASSWORD -> DEACTIVATED FOR FURTHER UPDATES */
            Console.WriteLine(string.IsNullOrWhiteSpace(email_input.Text));
            Console.WriteLine(string.IsNullOrWhiteSpace(password_input.Text));
            Console.WriteLine(email_input.Text == "Email");
            Console.WriteLine(password_input.Text == "Password");
            if (string.IsNullOrWhiteSpace(email_input.Text) || string.IsNullOrWhiteSpace(password_input.Text) || email_input.Text == "Email" || password_input.Text == "Password")
            {
                MessageBox.Show("Email and password are required");
            }
            else new Internal_Code(email_input.Text, password_input.Text, checkbox_remember.IsChecked);

            this.changeWindow();
        }

        public void changeWindow()
        {
            Main window = new Main();
            this.Close();
            window.Show();
        }
    }
}
