using EasyBase.src.code;
using EasyBase.src.ui.windows;
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

namespace EasyBase.src.ui.components
{
    /// <summary>
    /// Lógica de interacción para Navigation_Top.xaml
    /// </summary>
    public partial class Navigation_Top : UserControl
    {
        public Navigation_Top()
        {
            InitializeComponent();
        }

        public void navigate_to_main(object sender, RoutedEventArgs args)
        {
            Main windowMain = (Main)WindowDictionary.getWindow(typeof(Main));

            if (this.getActualWindow().GetType() != typeof(Main))
            {
                windowMain.Visibility = Visibility.Visible;
                this.getActualWindow().Visibility = Visibility.Hidden;
            }
        }

        public void navigate_to_user_profile(object sender, RoutedEventArgs args)
        {
            User_Profile windowUser = (User_Profile)WindowDictionary.getWindow(typeof(User_Profile));

            if (this.getActualWindow().GetType() != typeof(User_Profile))
            {
                windowUser.Visibility = Visibility.Visible;
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
