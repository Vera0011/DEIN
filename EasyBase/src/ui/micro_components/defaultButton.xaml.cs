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

namespace EasyBase.src.ui.micro_components
{
    /// <summary>
    /// Interaction logic for Buttons.xaml
    /// </summary>
    public partial class defaultButton : UserControl
    {
        public static readonly DependencyProperty ButtonText = DependencyProperty.Register("Text_Button", typeof(string), typeof(defaultButton), new PropertyMetadata(string.Empty));

        public defaultButton()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(ButtonText); }
            set { SetValue(ButtonText, value); }
        }

        private void Validate_Credentials(object sender, RoutedEventArgs e)
        {
            if (this.getActualWindow().GetType() == typeof(Login)) ((Login)WindowDictionary.getWindow(typeof(Login))).Validate_Credentials(sender, e);
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
