using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace coffe_app
{
    public partial class News : Window
    {
        private string selectedCulture;
        private MainWindow mainWindow;
        private bool isAdmin; // Добавим переменную для проверки прав администратора

        public News(string culture, MainWindow mainWindow, bool isAdmin)
        {
            InitializeComponent();
            selectedCulture = culture;
            this.mainWindow = mainWindow;
            this.isAdmin = isAdmin;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            ApplyLanguageResources();
            LoadNews();
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
            NewsLabel.Content = FindResource("News").ToString();
            BackToMainButton.Content = FindResource("Back").ToString();
            ExitButton.Content = FindResource("Exit").ToString();
            AddNewsButton.Content = FindResource("AddNews").ToString();

            // Скрываем кнопку "Добавить новость" для неадминистраторов
            AddNewsButton.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        public void LoadNews()
        {
            // Пример создания объектов NewsItem и их добавления в панель
            var newsItems = new List<NewsItem>
            {
                new NewsItem { Title = "Новое меню", Description = "В нашей кофейне появилось новое меню! Приходите и попробуйте наши новые напитки.", Date = DateTime.Now.ToString("dd.MM.yyyy") },
                new NewsItem { Title = "Скидки на выходные", Description = "Только в эти выходные - скидка 20% на все напитки!", Date = DateTime.Now.ToString("dd.MM.yyyy") },
            };

            foreach (var newsItem in newsItems)
            {
                NewsPanel.Children.Add(CreateNewsItem(newsItem));
            }
        }

        public UIElement CreateNewsItem(NewsItem newsItem)
        {
            var stackPanel = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(5) };

            var titleBlock = new TextBlock
            {
                Text = newsItem.Title,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            };

            var descriptionBlock = new TextBlock
            {
                Text = newsItem.Description,
                FontSize = 14,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            var dateBlock = new TextBlock
            {
                Text = $"Дата: {newsItem.Date}",
                FontSize = 12,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            stackPanel.Children.Add(titleBlock);
            stackPanel.Children.Add(descriptionBlock);
            stackPanel.Children.Add(dateBlock);

            return stackPanel;
        }

        public void OpenAddNewsWindow_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, является ли пользователь администратором
            if (isAdmin)
            {
                AddNewsWindow addNewsWindow = new AddNewsWindow(selectedCulture, this);
                addNewsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("У вас нет прав для добавления новостей.");
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

    // Пример класса NewsItem
    public class NewsItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}
