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
        private Order currentOrder;
        private List<Order> orders;
        private MainWindow mainWindow;
        private const string ServerIp = "127.0.0.1";
        private static int PORT = 11000;
        private string selectedCulture;
        private string username;

        public OrderWindow(Order currentOrder, List<Order> orders, MainWindow mainWindow, string culture, string username)
        {
            InitializeComponent();
            this.currentOrder = currentOrder;
            this.orders = orders; // Инициализируем переменную orders
            this.mainWindow = mainWindow;
            this.username = username;
            this.selectedCulture = culture;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            LoadOrder();
        }

        private void LoadOrder()
        {
            OrdersPanel.Children.Clear();

            if (currentOrder != null && currentOrder.components.Count > 0)
            {
                var orderPanel = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(5) };

                var usernameBlock = new TextBlock
                {
                    Text = $"Пользователь: {currentOrder.username}",
                    FontSize = 18
                };
                orderPanel.Children.Add(usernameBlock);

                foreach (var item in currentOrder.components)
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
                    Text = $"Статус заказа: {GetOrderStatus(currentOrder.status)}",
                    FontSize = 18,
                    Margin = new Thickness(0, 10, 0, 0)
                };
                orderPanel.Children.Add(statusBlock);

                var paymentStatusBlock = new TextBlock
                {
                    Text = $"Статус оплаты: {(currentOrder.pay ? "Оплачен" : "Не оплачен")}",
                    FontSize = 18,
                    Margin = new Thickness(0, 10, 0, 0)
                };
                orderPanel.Children.Add(paymentStatusBlock);

                var totalPriceBlock = new TextBlock
                {
                    Text = $"Сумма заказа: {currentOrder.price} рублей",
                    FontSize = 18
                };
                orderPanel.Children.Add(totalPriceBlock);

                OrdersPanel.Children.Add(orderPanel);
            }
            else
            {
                var emptyOrderBlock = new TextBlock
                {
                    Text = "Заказ отсутствует.",
                    FontSize = 18,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                OrdersPanel.Children.Add(emptyOrderBlock);
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
            string response = SendMessageToServer($"detailsOrder|{currentOrder.username}");

            if (!string.IsNullOrEmpty(response))
            {
                var updatedOrder = JsonSerializer.Deserialize<Order>(response);
                currentOrder.status = updatedOrder.status;
                currentOrder.price = updatedOrder.price;
                currentOrder.pay = updatedOrder.pay;
            }

            LoadOrder(); // Обновляем отображение заказа
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            string jsonOrder = JsonSerializer.Serialize(currentOrder);

            // Логируем JSON строку
            Console.WriteLine("JSON Order:");
            Console.WriteLine(jsonOrder);

            string message = $"createOrder|{currentOrder.username}|{jsonOrder}";

            // Логируем отправляемое сообщение
            Console.WriteLine("Отправляемое сообщение:");
            Console.WriteLine(message);

            string response = SendMessageToServer(message);

            // Логируем ответ сервера
            Console.WriteLine("Ответ сервера:");
            Console.WriteLine(response);

            if (response.Contains("успешно"))
            {
                MessageBox.Show("Заказ успешно отправлен!");
            }
            else
            {
                MessageBox.Show($"Ошибка при отправке заказа: {response}");
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

                    byte[] byteRec = new byte[2048]; // Увеличиваем размер буфера для получения ответа
                    EndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    int responseLength = s1.ReceiveFrom(byteRec, ref serverEndPoint);

                    string response = Encoding.UTF8.GetString(byteRec, 0, responseLength);

                    // Логируем ответ
                    Console.WriteLine("Получен ответ от сервера:");
                    Console.WriteLine(response);

                    return response;
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }
        private void DeleteOrder(string username)
        {
            string message = $"deleteOrder|{username}";
            string response = SendMessageToServer(message);

            // Логируем отправляемое сообщение и ответ сервера
            Console.WriteLine("Отправляемое сообщение для удаления заказа:");
            Console.WriteLine(message);
            Console.WriteLine("Ответ сервера:");
            Console.WriteLine(response);

            MessageBox.Show(response);
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            if (currentOrder.status == 4) // Статус "Выдан"
            {
                DeleteOrder(currentOrder.username);
            }
            mainWindow.Show();
            this.Close();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            if (currentOrder.status == 4) // Статус "Выдан"
            {
                DeleteOrder(currentOrder.username);
            }
            var menuWindow = new Menu(selectedCulture, mainWindow);
            menuWindow.Show();
            this.Close();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
