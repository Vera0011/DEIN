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
using System.Configuration;
using System.Data.SqlClient;

namespace SQL_Server_Connection
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();

            string connection = ConfigurationManager.ConnectionStrings["SQL_Server_Connection.Properties.Settings.alumta_deinConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connection);

            this.queryClients();
        }

        private void queryClients()
        {
            string query = "SELECT * FROM Usuarios WHERE user_type='user'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);

            using(adapter)
            {
                System.Data.DataTable users = new System.Data.DataTable();

                adapter.Fill(users);

                listClients.ItemsSource = users.DefaultView;
            }
        }
    }
}
