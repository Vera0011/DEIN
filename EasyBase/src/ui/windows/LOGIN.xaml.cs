﻿using EasyBase.src.code;
using EasyBase.src.code.auth;
using EasyBase.src.code.database;
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
    /// Lógica de interacción para LOGIN.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.Activate();
        }

        public void Validate_Credentials(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email_input.Text) || string.IsNullOrWhiteSpace(password_input.Text) || email_input.Text == "Email" || password_input.Text == "Password")
            {
                MessageBox.Show("Email and password are required");
            }
            else
            {
                new Internal_Auth(email_input.Text, password_input.Text, checkbox_remember.IsChecked);
            }
        }

        public void changeWindow()
        {
            ((Main)WindowDictionary.getWindow(typeof(Main))).Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
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
                if (email_input.Equals(textBox)) textBox.Text = "Email";
                else if (password_input.Equals(textBox)) textBox.Text = "Password";
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
