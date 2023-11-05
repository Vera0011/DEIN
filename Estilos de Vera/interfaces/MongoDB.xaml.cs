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

namespace Estilos_de_Vera
{
    /// <summary>
    /// Lógica de interacción para Window3.xaml
    /// </summary>
    public partial class MongoDB : Window
    {
        public MongoDB()
        {
            InitializeComponent();
        }

        public void sendToMySQL(object sender, RoutedEventArgs args)
        {
            MySQL window = new MySQL();
            this.Close();

            window.Show();
        }

        public void sendToMainWindow(object sender, RoutedEventArgs args)
        {
            MainWindow window = new MainWindow();
            this.Close();

            window.Show();
        }
    }
}
