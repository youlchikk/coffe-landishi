﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace coffe_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        { // Ваш код обработки нажатия кнопки здесь 
        }
        private void OpenProfile_Click(object sender, RoutedEventArgs e) 
        {
            Profile profileWindow = new Profile(this); 
            profileWindow.Show();
            this.Hide();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Menu menuWindow = new Menu(this);
            menuWindow.Show();
            this.Hide();
        }
        private void Exit_Click(object sender, RoutedEventArgs e) 
        { 
            Application.Current.Shutdown(); 
        }
    }
}