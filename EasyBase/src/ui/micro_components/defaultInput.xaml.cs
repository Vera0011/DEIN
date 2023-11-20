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
    /// Interaction logic for defaultInput.xaml
    /// </summary>
    public partial class defaultInput : UserControl
    {
        public static readonly DependencyProperty InputText = DependencyProperty.Register("Text_Input_Login", typeof(string), typeof(defaultButton), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty InputName = DependencyProperty.Register("Name_Input_Login", typeof(string), typeof(defaultButton), new PropertyMetadata(string.Empty));

        public defaultInput()
        {
            InitializeComponent();
        }

        private void RemoveDefaultText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text.Equals("Password") || textBox.Text.Equals("Email"))
            {
                textBox.Text = "";
            }
        }

        private void AddDefaultText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (Input_Name == "email_input") textBox.Text = "Email";
                else if (Input_Name == "password_input") textBox.Text = "Password";
            }
        }

        public string Text
        {
            get { return (string)GetValue(InputText); }
            set { SetValue(InputText, value); }
        }
        public string Input_Name
        {
            get { return (string)GetValue(InputName); }
            set { SetValue(InputName, value); }
        }
    }
}
