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
    /// Lógica de interacción para ListaEmpleados.xaml
    /// </summary>
    public partial class ListaEmpleados : Window
    {
        private Gestor gestionEmpleados;

        public ListaEmpleados()
        {
            InitializeComponent();
            gestionEmpleados = new Gestor();
            CargarEmpleadosEnDataGrid();
        }

        private void CargarEmpleadosEnDataGrid()
        {
            List<Empleado> empleados = gestionEmpleados.ObtenerEmpleados();
            dataGrid.ItemsSource = empleados;
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            new MainWindow().Show();
        }
    }

    public class Empleado
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public bool EsUsuario { get; set; }
        public int Edad { get; set; }
    }

    public partial class Gestor
    {
        private SqlConnection connection;

        public Gestor()
        {
            EstablecerConexion();
        }

        private void EstablecerConexion()
        {
            string CadenaDeConexion = ConfigurationManager.ConnectionStrings["GestionEmpleados2023.Properties.Settings.GestionEmpleadosConnectionString"].ConnectionString;
            this.connection = new SqlConnection(CadenaDeConexion);
        }

        public List<Empleado> ObtenerEmpleados()
        {
            EstablecerConexion();

            string consulta = "SELECT * FROM Empleados";
            DataTable Empleados = new DataTable();

            List<Empleado> listaEmpleados = new List<Empleado>();

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connection);

            using(adaptador)
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

            return listaEmpleados;
        }
    }
}
