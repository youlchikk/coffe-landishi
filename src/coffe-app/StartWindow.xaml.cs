using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using ServerCoffeeApp;

namespace coffe_app
{
    public partial class StartWindow : Window
    {
        public static int PORT = 11000;
        public string selectedCulture = "ru-RU";
        public bool isAdmin;
        public StartWindow()
        {
            FindIp();
            InitializeComponent();
            this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);
            SetLanguageResources();
        }
        public void FindIp()
        {
            IPHostEntry ipHostEntry = Dns.Resolve("youlchikk");
            IPAddress ip = ipHostEntry.AddressList[0];
            for (int i = 0; i < ipHostEntry.AddressList.Length; i++)
            {
                if (ipHostEntry.AddressList[i].IsIPv6LinkLocal == false)
                {
                    MainWindow.myIP = ipHostEntry.AddressList[i];
                }
            }

        }

        public void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)LanguageComboBox.SelectedItem;
            if (selectedItem != null)
            {
                selectedCulture = selectedItem.Tag.ToString();
                this.Language = XmlLanguage.GetLanguage(selectedCulture);
                ChangeLanguageDictionary(selectedCulture);
                SetLanguageResources();
            }
        }

        public void ChangeLanguageDictionary(string culture)
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (culture)
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
        }

        public void SetLanguageResources()
        {
            LoginButton.Content = FindResource("Next").ToString();
            RegisterButton.Content = FindResource("Next").ToString();
            ExitButton.Content = FindResource("Exit").ToString();
            LoginTab.Header = FindResource("Login").ToString();
            RegisterTab.Header = FindResource("Register").ToString();

            // Обновляем текстовые метки для всех элементов
            LoginUsernamePlaceholder.Content = FindResource("Username").ToString();
            LoginPasswordPlaceholder.Content = FindResource("Password").ToString();
            RegisterUsernamePlaceholder.Content = FindResource("Username").ToString();
            RegisterPhonePlaceholder.Content = FindResource("Phone").ToString();
            RegisterEmailPlaceholder.Content = FindResource("Email").ToString();
            RegisterBirthdatePlaceholder.Content = FindResource("Birthdate").ToString();
            RegisterPasswordPlaceholder.Content = FindResource("Password").ToString();
        }

        public void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginUsername.Text;
            string password = LoginPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            string response = SendMessageToServer($"login|{username}|{password}");
            if (response.Contains("аутентификация успешна", StringComparison.OrdinalIgnoreCase))
            {
                isAdmin = SendMessageToServer($"admin?|{username}").Contains("администратор");
                MainWindow mainWindow = new MainWindow(selectedCulture, username, isAdmin);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка аутентификации!");
            }
        }

        public void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = RegisterUsername.Text;
            string phone = RegisterPhone.Text;
            string email = RegisterEmail.Text;
            string birthdate = RegisterBirthdate.SelectedDate?.ToString("dd/MM/yyyy");
            string password = RegisterPassword.Password;
            bool admin = false; // Определите, нужен ли вам какой-то способ установить флаг администратора

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Некорректный формат электронной почты!");
                return;
            }

            if (!IsValidPhone(phone))
            {
                MessageBox.Show("Некорректный формат номера телефона!");
                return;
            }

            string response = SendMessageToServer($"register|{username}|{phone}|{email}|{birthdate}|{password}|{admin}");
            if (response.Contains("регистрация успешна", StringComparison.OrdinalIgnoreCase))
            {
                isAdmin = SendMessageToServer($"admin?|{username}").Contains("администратор");
                MessageBox.Show("Регистрация успешна!");
                MainWindow mainWindow = new MainWindow(selectedCulture, username, isAdmin);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован!");
            }
        }

        public string SendMessageToServer(string message)
        {
            try
            {
                Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint serverEndpoint = new IPEndPoint(MainWindow.myIP, PORT);

                byte[] data = Encoding.UTF8.GetBytes(message);
                s1.SendTo(data, data.Length, SocketFlags.None, serverEndpoint);
                byte[] byteRec = new byte[512];
                EndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
                int responseLength = s1.ReceiveFrom(byteRec, ref serverEndPoint);

                return Encoding.UTF8.GetString(byteRec, 0, responseLength);
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public bool IsValidPhone(string phone)
        {
            string pattern = @"^\+?[1-9]\d{6,14}$";
            return Regex.IsMatch(phone, pattern);
        }
    }
}
