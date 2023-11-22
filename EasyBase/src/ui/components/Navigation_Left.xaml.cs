using System.Windows;
using System.Windows.Controls;

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
            }
        }

        public void navigate_to_manage(object sender, RoutedEventArgs args)
        {

        }

        public void navigate_to_export(object sender, RoutedEventArgs args)
        {

        }

        public void navigate_to_access(object sender, RoutedEventArgs args)
        {

        }
    }
}
