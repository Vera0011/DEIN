using EasyBase.src.code;
using EasyBase.src.code.auth;
using Newtonsoft.Json;
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
    /// Lógica de interacción para Database_Window.xaml
    /// </summary>
    public partial class Database_Window : Window
    {
        private Style styleCollapsed = new Style { TargetType = typeof(Label) };
        private Style styleVisible = new Style { TargetType = typeof(Label) };
        public Database_Window()
        {
            InitializeComponent();
            this.styleCollapsed.Setters.Add(new Setter(VisibilityProperty, Visibility.Collapsed));
            this.styleVisible.Setters.Add(new Setter(VisibilityProperty, Visibility.Visible));
            this.Activate();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        public void load_Users(object sender, RoutedEventArgs args)
        {
            //Internal_Auth.load_data(JsonConvert.SerializeObject(new { collection = "Users", query = "" }));
            table_label.Content = "MongoDB > Users";
            
            this.Resources["dataUsers"] = styleVisible;
            this.Resources["dataProducts"] = styleCollapsed;
            this.Resources["dataEmployees"] = styleCollapsed;

            third_col.Content = "Surname";
            forth_col.Content = "Balance";
        }

        public void load_Products(object sender, RoutedEventArgs args)
        {
            //Internal_Auth.load_data(JsonConvert.SerializeObject(new { collection = "Products", query = "" }));
            table_label.Content = "MongoDB > Products";

            this.Resources["dataUsers"] = styleCollapsed;
            this.Resources["dataProducts"] = styleVisible;
            this.Resources["dataEmployees"] = styleCollapsed;

            third_col.Content = "Surname";
            forth_col.Content = "Salary";
        }

        public void load_Employees(object sender, RoutedEventArgs args)
        {
            //Internal_Auth.load_data(JsonConvert.SerializeObject(new { collection = "Employees", query = "" }));
            table_label.Content = "MongoDB > Employees";

            this.Resources["dataUsers"] = styleCollapsed;
            this.Resources["dataProducts"] = styleCollapsed;
            this.Resources["dataEmployees"] = styleVisible;

            third_col.Content = "Stock";
            forth_col.Content = "Price";
        }

        private void RemoveDefaultText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Equals("Search"))
            {
                textBox.Text = "";
            }
        }

        private void AddDefaultText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (search_input.Equals(textBox)) textBox.Text = "Search";
            }
        }
    }
}
