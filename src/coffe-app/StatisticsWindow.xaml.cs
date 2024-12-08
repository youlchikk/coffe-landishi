using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace coffe_app
{
    public partial class StatisticsWindow : Window
    {
        private MainWindow mainWindow;
        private string selectedCulture;
        private string ServerIp = MainWindow.myIP; // Замените на IP-адрес вашего сервера
        private static int PORT = 11000;

        public StatisticsWindow(MainWindow mainWindow, string culture)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.selectedCulture = culture;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            string archiveData = GetArchiveDataFromServer();
            if (!string.IsNullOrEmpty(archiveData))
            {
                var statistics = ParseArchiveData(archiveData);
                DisplayStatistics(statistics);
            }
            else
            {
                MessageBox.Show("Не удалось загрузить данные архива.");
            }
        }

        private string GetArchiveDataFromServer()
        {
            try
            {
                using (Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse(ServerIp), PORT);

                    string message = "getArchive"; // Команда для получения данных архива
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    s1.SendTo(data, data.Length, SocketFlags.None, serverEndpoint);

                    byte[] byteRec = new byte[2048];
                    EndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    int responseLength = s1.ReceiveFrom(byteRec, ref serverEndPoint);

                    string response = Encoding.UTF8.GetString(byteRec, 0, responseLength);
                    MessageBox.Show(response);
                    return response;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении данных архива: {ex.Message}");
                return string.Empty;
            }
        }


        private List<ArchiveRecord> ParseArchiveData(string archiveData)
        {
            var records = new List<ArchiveRecord>();
            var entries = archiveData.Split('|');
            foreach (var entry in entries)
            {
                MessageBox.Show(entry);
                var parts = entry.Split(' ');
                if (parts.Length == 3)
                {
                    if (DateTime.TryParseExact(parts[1], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)
                        && double.TryParse(parts[2], NumberStyles.Any, new CultureInfo("fr-FR"), out var price))
                    {
                        records.Add(new ArchiveRecord
                        {
                            Username = parts[0],
                            Date = date,
                            Price = price
                        });
                    }
                }
            }

            return records;
        }

        private void DisplayStatistics(List<ArchiveRecord> statistics)
        {
            StatisticsPanel.Children.Clear();
            foreach (var record in statistics)
            {
                var recordPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

                var usernameBlock = new TextBlock
                {
                    Text = $"Пользователь: {record.Username}",
                    FontSize = 16,
                    Margin = new Thickness(5, 0, 5, 0)
                };
                recordPanel.Children.Add(usernameBlock);

                var dateBlock = new TextBlock
                {
                    Text = $"Дата: {record.Date.ToString("yyyy-MM-dd")}",
                    FontSize = 16,
                    Margin = new Thickness(5, 0, 5, 0)
                };
                recordPanel.Children.Add(dateBlock);

                var priceBlock = new TextBlock
                {
                    Text = $"Сумма: {record.Price} рублей",
                    FontSize = 16,
                    Margin = new Thickness(5, 0, 5, 0)
                };
                recordPanel.Children.Add(priceBlock);

                StatisticsPanel.Children.Add(recordPanel);

                Console.WriteLine($"Отображение записи: Пользователь = {record.Username}, Дата = {record.Date.ToString("yyyy-MM-dd")}, Сумма = {record.Price} рублей"); // Логируем отображаемую запись
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

    public class ArchiveRecord
    {
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
