using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MenuDLL;

namespace coffe_app
{
    public partial class OrderWindow : Window
    {
        private List<Order> orders;
        private MainWindow mainWindow;
        private const string ServerIp = "127.0.0.1"; // Замените на IP-адрес вашего сервера
        private static int PORT = 11000;
        private string selectedCulture;
        private string username;

        public OrderWindow(List<Order> orders, MainWindow mainWindow, string culture, string username)
        {
            InitializeComponent();
            this.orders = orders;
            this.mainWindow = mainWindow;
            this.username = username;
            this.selectedCulture = culture;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            LoadOrders();
        }

        private void LoadOrders()
        {
            OrdersPanel.Children.Clear();

            foreach (var order in orders)
            {
                var orderPanel = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(5) };

                var usernameBlock = new TextBlock
                {
                    Text = $"Пользователь: {order.username}",
                    FontSize = 18
                };
                orderPanel.Children.Add(usernameBlock);

                foreach (var item in order.components)
                {
                    var itemBlock = new TextBlock
                    {
                        Text = $"{item.description} - {item.price} рублей",
                        FontSize = 16
                    };
                    orderPanel.Children.Add(itemBlock);
                }

                var statusBlock = new TextBlock
                {
                    Text = $"Статус: {GetOrderStatus(order.status)}",
                    FontSize = 18
                };
                orderPanel.Children.Add(statusBlock);

                var paidBlock = new TextBlock
                {
                    Text = $"Оплачен: {(order.pay ? "Да" : "Нет")}",
                    FontSize = 18
                };
                orderPanel.Children.Add(paidBlock);

                var itemsCountBlock = new TextBlock
                {
                    Text = $"Число позиций: {order.components.Count}",
                    FontSize = 18
                };
                orderPanel.Children.Add(itemsCountBlock);

                var totalPriceBlock = new TextBlock
                {
                    Text = $"Сумма заказа: {order.price} рублей",
                    FontSize = 18
                };
                orderPanel.Children.Add(totalPriceBlock);

                OrdersPanel.Children.Add(orderPanel);
            }
        }

        private string GetOrderStatus(int status)
        {
            return status switch
            {
                1 => "Принят",
                2 => "Готовится",
                3 => "Готов",
                4 => "Выдан",
                _ => "Неизвестен"
            };
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            foreach (var order in orders)
            {
                string response = SendMessageToServer($"detailsOrder|{order.username}");
                if (!string.IsNullOrEmpty(response) && response.Contains("успешно"))
                {
                    var updatedOrder = JsonSerializer.Deserialize<Order>(response);
                    order.status = updatedOrder.status;
                    order.pay = updatedOrder.pay;
                }
            }
            LoadOrders();
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            foreach (var order in orders)
            {
                string jsonOrder = JsonSerializer.Serialize(order);

                // Логируем JSON строку
                MessageBox.Show("JSON Order:");
                MessageBox.Show(jsonOrder);

                string message = $"createOrder|{order.username}|{jsonOrder}";

                // Логируем отправляемое сообщение
                MessageBox.Show("Отправляемое сообщение:");
                MessageBox.Show(message);

                string response = SendMessageToServer(message);

                // Логируем ответ сервера
                MessageBox.Show("Ответ сервера:");
                MessageBox.Show(response);

                if (response.Contains("успешно"))
                {
                    MessageBox.Show("Заказ успешно отправлен!");
                }
                else
                {
                    MessageBox.Show($"Ошибка при отправке заказа: {response}");
                }
            }
        }

        private string SendMessageToServer(string message)
        {
            try
            {
                using (Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse(ServerIp), PORT);

                    byte[] data = Encoding.UTF8.GetBytes(message);
                    s1.SendTo(data, data.Length, SocketFlags.None, serverEndpoint);

                    byte[] byteRec = new byte[512];
                    EndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    int responseLength = s1.ReceiveFrom(byteRec, ref serverEndPoint);

                    return Encoding.UTF8.GetString(byteRec, 0, responseLength);
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new Menu(selectedCulture, mainWindow, username);
            menuWindow.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
