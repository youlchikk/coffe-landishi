using System;
using System.Globalization;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using MenuDLL;

namespace coffe_app
{
    public partial class MainWindow : Window
    {
        private string selectedCulture;
        private string username;
        private bool isAdmin;
        public MainWindow(string culture, string username, bool isAdmin)
        {
            InitializeComponent();
            selectedCulture = culture;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            ApplyLanguageResources();
            this.username=username;
            this.isAdmin=isAdmin;
            SetupAdminButtons();
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
            GreetingLabel.Content = FindResource("Greeting").ToString();
            MenuButton.Content = FindResource("Menu").ToString();
            DealsButton.Content = FindResource("Deals").ToString();
            OrderButton.Content = FindResource("OrderWindow").ToString();
            ProfileButton.Content = FindResource("Profile").ToString();
            NewsButton.Content = FindResource("News").ToString();
            ExitButton.Content = FindResource("Exit").ToString();
        }
        private void SetupAdminButtons()
        { 
            AdminButtonsPanel.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed; 
        }
        private void StatusOrder_Click(object sender, RoutedEventArgs e)
        {
            // Предполагается, что у вас есть список заказов и текущая культура
            List<Order> orders = GetOrdersFromServer(); // Метод для получения списка заказов с сервера
            string selectedCulture = "ru-RU"; // Пример значения, замените на актуальное значение

            var changeOrderStatusWindow = new ChangeOrderStatusWindow(orders, this, selectedCulture, username);
            changeOrderStatusWindow.Show();
            this.Hide(); // Закрываем текущее окно
        }
        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            // Предполагается, что текущая культура уже определена
            string selectedCulture = "ru-RU"; // Пример значения, замените на актуальное значение

            var statisticsWindow = new StatisticsWindow(this, selectedCulture);
            statisticsWindow.Show();
            this.Hide(); // Закрываем текущее окно
        }
        private List<Order> GetOrdersFromServer()
        {
            try
            {
                using (Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {

                    IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000); // Замените на IP-адрес и порт вашего сервера

                    string message = "getOrders|all"; // Команда для получения всех заказов
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    s1.SendTo(data, data.Length, SocketFlags.None, serverEndpoint);

                    byte[] byteRec = new byte[2048];
                    EndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    int responseLength = s1.ReceiveFrom(byteRec, ref serverEndPoint);

                    string response = Encoding.UTF8.GetString(byteRec, 0, responseLength);

                    string[] parts = response.Split('|');

                    List <Order> orders = new List<Order>();
                    for(int i = 0; i < parts.Length; i++)
                    {
                        orders.Add(JsonSerializer.Deserialize<Order>(parts[i]));
                    }

                    return orders;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении заказов: {ex.Message}");
                return new List<Order>();
            }
        }

        private void OpenProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profileWindow = new Profile(selectedCulture, this, username);
            profileWindow.Show();
            this.Hide();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Menu menuWindow = new Menu(selectedCulture, this, username);
            menuWindow.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Deals_Click(object sender, RoutedEventArgs e)
        {
            Promotions promotionsWindow = new Promotions(selectedCulture, this);
            promotionsWindow.Show();
            this.Hide();
        }
        private void News_Click(object sender, RoutedEventArgs e) 
        { 
            News newsWindow = new News(selectedCulture, this, isAdmin); 
            newsWindow.Show(); 
            this.Hide(); 
        }
        private void OrderWindow_Click(object sender, RoutedEventArgs e)
        {
            Order orderWindow = new Order();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
