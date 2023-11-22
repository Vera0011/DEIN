using EasyBase.src.ui.micro_components;
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
    /// Lógica de interacción para Wrap_Databases_Main.xaml
    /// </summary>
    public partial class Wrap_Databases_Main : UserControl
    {
        public static readonly DependencyProperty Image_Field = DependencyProperty.Register("Image", typeof(string), typeof(Wrap_Databases_Main), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty Text_Field = DependencyProperty.Register("Text", typeof(string), typeof(Wrap_Databases_Main), new PropertyMetadata(string.Empty));

        public Wrap_Databases_Main(string name, string image)
        {
            InitializeComponent();
            Text_Item.Text = name;
            //Image_Item.Source = new BitmapImage(new Uri(string.Format(@"..\..\{0}", image), UriKind.Relative));
        }

        public string Text
        {
            get { return (string)GetValue(Text_Field); }
            set { SetValue(Text_Field, value); }
        }
        public string Image
        {
            get { return (string)GetValue(Image_Field); }
            set { SetValue(Image_Field, value); }
        }
    }
}
