using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
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

namespace GestionEmpleados2023
{
    /// <summary>
    /// Lógica de interacción para AgregarEmpleado.xaml
    /// </summary>
    public partial class AgregarEmpleado : Window
    {
        public AgregarEmpleado()
        {
            InitializeComponent();
        }

        public void AgregarEmpleado_Click(object sender, RoutedEventArgs args)
        {
            string nombre = txtNombre.Text;
            string apellidos = txtNombre.Text;
            bool usuario = checkboxUsuario.IsChecked ?? false;
            int edad;

            if (int.TryParse(txtEdad.Text, out edad))
            {
                AgregarEmpleadoString(nombre, apellidos, usuario, edad);
                Close();
            }
            else MessageBox.Show("Ingrese una edad válida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AgregarEmpleadoString(string nombre, string apellidos, bool usuario, int edad)
        {
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GestionEmpleados2023.Properties.Settings.GestionEmpleadosConnectionString"].ConnectionString))
            {
                string consulta = "INSERT INTO Empleados (nombre, apellidos, esUsuario, edad) VALUES (@nombre, @apellidos, @esUsuario, @edad)";

                using(SqlCommand cmd = new SqlCommand(consulta, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@esUsuario", usuario);
                    cmd.Parameters.AddWithValue("@edad", edad);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Error al agregar el empleado " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    this.Close();
                }
            }
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
