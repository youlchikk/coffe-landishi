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
    public partial class ChangeOrderStatusWindow : Window
    {
        private List<Order> orders;
        private MainWindow mainWindow;
        private const string ServerIp = "127.0.0.1"; // Замените на IP-адрес вашего сервера
        private static int PORT = 11000;
        private string selectedCulture;
        private string username;

        public ChangeOrderStatusWindow(List<Order> orders, MainWindow mainWindow, string culture, string username)
        {
            InitializeComponent();
            this.orders = orders;
            this.mainWindow = mainWindow;
            this.selectedCulture = culture;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            LoadOrders();
            this.username=username;
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

                var statusBlock = new ComboBox
                {
                    ItemsSource = new List<string> { "Принят", "Готовится", "Готов", "Выдан" },
                    SelectedValue = GetOrderStatus(order.status),
                    FontSize = 18
                };
                statusBlock.SelectionChanged += (s, e) => ChangeOrderStatus(order.username, statusBlock.SelectedValue.ToString());
                orderPanel.Children.Add(statusBlock);

                var paidBlock = new CheckBox
                {
                    Content = "Оплачен",
                    IsChecked = order.pay,
                    FontSize = 18
                };
                paidBlock.Checked += (s, e) => ChangeOrderPayment(order.username, true);
                paidBlock.Unchecked += (s, e) => ChangeOrderPayment(order.username, false);
                orderPanel.Children.Add(paidBlock);

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
        private void ChangeOrderStatus(string username, string status)
        {
            string statusCommand = status switch
            {
                "Принят" => "nextStatusOrder",
                "Готовится" => "nextStatusOrder",
                "Готов" => "nextStatusOrder",
                "Выдан" => "nextStatusOrder",
                _ => throw new ArgumentException("Invalid status")
            };

            string message = $"{statusCommand}|{username}";
            string response = SendMessageToServer(message);

            // Логирование отправляемого сообщения и ответа сервера
            MessageBox.Show("Отправляемое сообщение:");
            MessageBox.Show(message);
            MessageBox.Show("Ответ сервера:");
            MessageBox.Show(response);

            MessageBox.Show(response);
        }

        private void ChangeOrderPayment(string username, bool payment)
        {
            string message = payment ? $"PaymentOrder|{username}" : $"UnpaymentOrder|{username}"; // Обновите на корректную команду, если требуется
            string response = SendMessageToServer(message);

            // Логирование отправляемого сообщения и ответа сервера
            Console.WriteLine("Отправляемое сообщение:");
            Console.WriteLine(message);
            MessageBox.Show("Ответ сервера:");
            MessageBox.Show(response);

            MessageBox.Show(response);
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


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
