using EasyBase.src.code;
using EasyBase.src.ui.windows;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EasyBase.src.ui.components
{
    /// <summary>
    /// Lógica de interacción para Navigation_Left.xaml
    /// </summary>
    public partial class Navigation_Left : UserControl
    {
        public Navigation_Left()
        {
            InitializeComponent();
        }
        
        public void change_button_states(object sender, RoutedEventArgs args)
        {
            Button[] buttons = { manage_button, access_button, export_button};

            foreach (Button button in buttons)
            {
                if (button.IsVisible) button.Visibility = Visibility.Collapsed;
                else button.Visibility = Visibility.Visible;

                if(main_button_image.Source.ToString().Contains("down_arrow")) main_button_image.Source = new BitmapImage(new Uri(string.Format(@"../imgs/up_arrow.png"), UriKind.Relative));
                else main_button_image.Source = new BitmapImage(new Uri(string.Format(@"../imgs/down_arrow.png"), UriKind.Relative));
            }
        }

        public void navigate_to_manage(object sender, RoutedEventArgs args)
        {
            Manage_Window windowManage = (Manage_Window)WindowDictionary.getWindow(typeof(Manage_Window));

            if (this.getActualWindow().GetType() != typeof(Manage_Window))
            {
                if (windowManage == null) new Manage_Window().Show();
                else windowManage.Visibility = Visibility.Visible;
            }
        }

        public void navigate_to_export(object sender, RoutedEventArgs args)
        {
            Export_Window windowExport = (Export_Window)WindowDictionary.getWindow(typeof(Export_Window));

            if (this.getActualWindow().GetType() != typeof(Export_Window))
            {
                if (windowExport == null) new Export_Window().Show();
                else windowExport.Visibility = Visibility.Visible;
            }
        }

        public void navigate_to_access(object sender, RoutedEventArgs args)
        {
            Database_Window windowDatabase = (Database_Window)WindowDictionary.getWindow(typeof(Database_Window));

            if (this.getActualWindow().GetType() != typeof(Database_Window))
            {
                if (windowDatabase == null) new Database_Window().Show();
                else windowDatabase.Visibility = Visibility.Visible;

                this.getActualWindow().Visibility = Visibility.Hidden;
            }
        }

        public void navigate_to_login(object sender, RoutedEventArgs args)
        {
            Login windowLogin = (Login)WindowDictionary.getWindow(typeof(Login));

            if (this.getActualWindow().GetType() != typeof(Login))
            {
                if (windowLogin == null) new Login().Show();
                else windowLogin.Visibility = Visibility.Visible;

                this.getActualWindow().Visibility = Visibility.Hidden;
            }
        }

        private Window getActualWindow()
        {
            DependencyObject parent = this;

            while (parent != null && !(parent is Window))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return (Window)parent;
        }
    }
}
