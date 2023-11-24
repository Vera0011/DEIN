using EasyBase.src.code;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyBase.src.ui.windows
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            this.Activate();
        }

        /* Get all databases from user -> DEACTIVATED FOR FURTHER UPDATES */
        public void get_databases(object sender, EventArgs args)
        {

        }

        public void go_to_database(object sender, EventArgs args)
        {
            ((Database_Window)WindowDictionary.getWindow(typeof(Database_Window))).Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
