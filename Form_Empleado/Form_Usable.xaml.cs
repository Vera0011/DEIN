﻿using Microsoft.Win32;
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

namespace Form_Empleado
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Form_Usable : Window
    {
        public Form_Usable()
        {
            InitializeComponent();
        }

        public void uploadImage(object sender, RoutedEventArgs args)
        {
            // A que no te esperabas esto, eh Alberto
            if ((Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift | ModifierKeys.Alt)) == (ModifierKeys.Control | ModifierKeys.Shift | ModifierKeys.Alt))
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    imageUploaded.Source = new BitmapImage(new Uri(op.FileName));
                }
            }
            else button.IsEnabled = false;
        }

        public void appendData(object sender, RoutedEventArgs args)
        {
            if (Keyboard.IsKeyDown(Key.Z) && Keyboard.IsKeyDown(Key.O) && Keyboard.IsKeyDown(Key.M))
            {
                if (imageUploaded.Source == null)
                {
                    MessageBox.Show("Append an image");
                    this.Close();
                }

                object[] values = { this.FindName("name"), this.FindName("surname"), this.FindName("email"), this.FindName("phone") };
                object[] fields = { "Nombre", "Apellidos", "E-Mail", "Teléfono"};
                bool status = true;


                for (int i = 0; i < values.Length; i++)
                {
                    if (string.IsNullOrEmpty(((TextBox)values[i]).Text))
                    {
                        status = false;
                        MessageBox.Show("Field " + fields[i] + " is required");
                        this.Close();
                    };
                }

                if (status)
                {
                    ((DataGrid)this.FindName("dataGrid")).Items.Add(new User() { name = ((TextBox)values[0]).Text, surname = ((TextBox)values[1]).Text, email = ((TextBox)values[2]).Text, phone = ((TextBox)values[3]).Text });
                }

            } else button2.IsEnabled = false;
        }

        public void clearInput(object sender, RoutedEventArgs args)
        {
            ((TextBox)sender).Text = "";
        }

        public void fillInput(object sender, RoutedEventArgs args)
        {
            TextBox text = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(text.Text)) text.Text = text.Name.Replace('_', ' ');
        }

        public void closeAndOpen(object sender, RoutedEventArgs args)
        {
            this.Close();
        }
    }

    public class User
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}