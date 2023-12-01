using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace GestionEmpleados2023
{
    /// <summary>
    /// Lógica de interacción para BuscarEmpleado.xaml
    /// </summary>
    public partial class BuscarEmpleado : Window
    {
        public BuscarEmpleado()
        {
            InitializeComponent();
        }
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            new MainWindow().Show();
        }

        public void search_employee(object sender, EventArgs args)
        {
            PerformAction(nombre_txt.Text, apellido_txt.Text, "select");
        }

        public void delete_employee(object sender, EventArgs args)
        {
            PerformAction(nombre_txt.Text, apellido_txt.Text, "delete");
        }

        private void PerformAction(string nombre, string apellido, string type)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GestionEmpleados2023.Properties.Settings.GestionEmpleadosConnectionString"].ConnectionString))
            {
                string consulta = "SELECT * FROM Empleados WHERE nombre = '" + nombre + "' AND apellidos = '" + apellido + "'";
                DataTable Empleados = new DataTable();

                List<Empleado> listaEmpleados = new List<Empleado>();

                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);

                using (adaptador)
                {
                    adaptador.Fill(Empleados);
                }
                listaEmpleados = Empleados.AsEnumerable().Select(row => new Empleado
                {
                    Nombre = row.Field<string>("nombre"),
                    Apellidos = row.Field<string>("apellidos"),
                    EsUsuario = (row["EsUsuario"] != DBNull.Value) ? row.Field<bool>("esUsuario") : false,
                    Edad = row.Field<int>("edad")
                }).ToList();

                dataGrid.ItemsSource = listaEmpleados;

                if (type == "delete")
                {
                    consulta = "DELETE FROM Empleados WHERE nombre = @nombre AND apellidos = @apellidos";
                    
                    using (SqlCommand cmd = new SqlCommand(consulta, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellidos", apellido);

                        try
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error al ejecutar la sentencia sql: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }
    }
}
