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
        public static Order CurrentOrder { get; set; }
        public static IPAddress myIP;
        private string selectedCulture;
        private string username;
        private bool isAdmin;
        public MainWindow(string culture, string username, bool isAdmin)
        {
            InitializeComponent();
            selectedCulture = culture;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            ApplyLanguageResources();
            this.username = username;
            CurrentOrder = new Order(username, 0, new List<MenuDLL.Menu>());
            this.isAdmin = isAdmin;
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
            //Обновляем текст для кнопок администратора 
            StatusOrderButton.Content = FindResource("StatusOrder").ToString(); 
            StatisticsButton.Content = FindResource("Statistics").ToString();
        }

        private void SetupAdminButtons()
        {
            AdminButtonsPanel.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void StatusOrder_Click(object sender, RoutedEventArgs e)
        {
            List<Order> orders = GetOrdersFromServer();
            var changeOrderStatusWindow = new ChangeOrderStatusWindow(orders, this, selectedCulture, username);
            changeOrderStatusWindow.Show();
            this.Hide(); // Скрываем текущее окно
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            var statisticsWindow = new StatisticsWindow(this, selectedCulture);
            statisticsWindow.Show();
            this.Hide(); // Скрываем текущее окно
        }

        private List<Order> GetOrdersFromServer()
        {
            try
            {
                using (Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    IPEndPoint serverEndpoint = new IPEndPoint(MainWindow.myIP, 11000); // Замените на IP-адрес и порт вашего сервера

                    string message = "getOrders|all";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    s1.SendTo(data, data.Length, SocketFlags.None, serverEndpoint);

                    byte[] byteRec = new byte[2048];
                    EndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    int responseLength = s1.ReceiveFrom(byteRec, ref serverEndPoint);

                    string response = Encoding.UTF8.GetString(byteRec, 0, responseLength);

                    string[] parts = response.Split('|');

                    List<Order> orders = new List<Order>();
                    for (int i = 0; i < parts.Length; i++)
                    {
                        orders.Add(JsonSerializer.Deserialize<Order>(parts[i]));
                    }

                    return orders;
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show($"Ошибка при получении заказов: {ex.Message}");
                return new List<Order>();
            }
        }

        private void OpenProfile_Click(object sender, RoutedEventArgs e)
        {
            var profileWindow = new Profile(selectedCulture, this, username);
            profileWindow.Show();
            this.Hide();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new Menu(selectedCulture, this);
            menuWindow.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Deals_Click(object sender, RoutedEventArgs e)
        {
            var promotionsWindow = new Promotions(selectedCulture, this);
            promotionsWindow.Show();
            this.Hide();
        }

        private void News_Click(object sender, RoutedEventArgs e)
        {
            var newsWindow = new News(selectedCulture, this, isAdmin);
            newsWindow.Show();
            this.Hide();
        }

        private void OrderWindow_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderWindow(MainWindow.CurrentOrder, new List<Order>(), this, selectedCulture, MainWindow.CurrentOrder.username);
            orderWindow.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Пустой метод для обработки событий
        }
    }
}
