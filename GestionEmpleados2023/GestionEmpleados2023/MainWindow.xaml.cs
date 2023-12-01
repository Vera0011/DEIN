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

namespace GestionEmpleados2023
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void navigate_to_list(object sender, RoutedEventArgs args)
        {
            new ListaEmpleados().Show();
            this.Close();
        }

        public void navigate_to_add(object sender, RoutedEventArgs args)
        {
            new AgregarEmpleado().Show();
            this.Close();
        }

        public void navigate_to_select(object sender, RoutedEventArgs args)
        {
            new BuscarEmpleado().Show();
            this.Close();
        }
    }
}
