﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace coffe_app
{
    public partial class Profile : Window
    {
        private const string ServerIp = "127.0.0.1"; 
        private static int PORT = 11000; 
        private string selectedCulture; 
        private MainWindow mainWindow; 
        private string username;

        public Profile(string culture, MainWindow mainWindow, string username) 
        { 
            InitializeComponent(); 
            selectedCulture = culture; 
            this.mainWindow = mainWindow; 
            this.username = username; 
            this.Language = XmlLanguage.GetLanguage(selectedCulture); 
            ApplyLanguageResources(); 
            LoadUserData(); 
        }

        private void ApplyLanguageResources()
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (selectedCulture)
            {
                case "ru-RU":
                    dict.Source = new Uri("Resources/StringResources.ru-RU.xaml", UriKind.Relative);
                    break;
                case "en-US":
                default:
                    dict.Source = new Uri("Resources/StringResources.en-US.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dict);

            // Обновляем текстовые метки для всех элементов
            ProfileLabel.Content = FindResource("Profile").ToString();
            BackToMainButton.Content = FindResource("Back").ToString();
            ExitButton.Content = FindResource("Exit").ToString();
            NumberLabel.Content = FindResource("Phone").ToString();
            EmailLabel.Content = FindResource("Email").ToString();
            BirthdayLabel.Content = FindResource("Birthdate").ToString();
            NameLabel.Content = FindResource("Username").ToString();
        }
         private void LoadUserData()
        {
            var userFromServer = GetUserFromServer(username); if (userFromServer != null)
            {
                NameLabel.Content = userFromServer[0]; 
                NumberLabel.Content = userFromServer[1]; 
                EmailLabel.Content = userFromServer[2]; 
                BirthdayLabel.Content = userFromServer[3]; 
            } 
        } 
        private string[] GetUserFromServer(string username) 
        { 
            try 
            {
                Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); 
                IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse(ServerIp), PORT); 
                string message = $"get_user|{username}"; 
                byte[] data = Encoding.UTF8.GetBytes(message); 
                s1.SendTo(data, data.Length, SocketFlags.None, serverEndpoint); 
                byte[] byteRec = new byte[512]; 
                EndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0); 
                int responseLength = s1.ReceiveFrom(byteRec, ref serverEndPoint); 
                string response = Encoding.UTF8.GetString(byteRec, 0, responseLength); 
                return response.Split('|'); 
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Ошибка: {ex.Message}"); return null; 
            }
        }
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
