using Microsoft.Win32;
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

namespace Form_Empleado
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

        public void uploadImage(object sender, RoutedEventArgs args)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                imageUploaded.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        public void appendData(object sender, RoutedEventArgs args)
        {
            object[] values = { this.FindName("name"), this.FindName("surname"), this.FindName("email"), this.FindName("phone") };
            bool status = true;

            for (int i = 0; i < values.Length; i++)
            {
                if (string.IsNullOrEmpty(((TextBox)values[i]).Text)) { status = false; break; };
            }

            if (status)
            {
                ((DataGrid)this.FindName("dataGrid")).Items.Add(new User() { name = ((TextBox)values[0]).Text, surname = ((TextBox)values[1]).Text, email = ((TextBox)values[2]).Text, phone = ((TextBox)values[3]).Text };);
            }
        }

        public void clearInput(object sender, RoutedEventArgs args)
        {
            ((TextBox)sender).Text = "";
        }

        public void fillInput(object sender, RoutedEventArgs args)
        {
            TextBox text = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(text.Text)) text.Text = text.Name.Replace('_', ' ');
        }

        public void closeAndOpen(object sender, RoutedEventArgs args)
        {
            new MainWindow().Show();
            this.Close();
        }
    }

    public class User
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}