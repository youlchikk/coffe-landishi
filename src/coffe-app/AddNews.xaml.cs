using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace coffe_app
{
    public partial class AddNewsWindow : Window
    {
        private string selectedCulture;
        private News newsWindow;

        public AddNewsWindow(string culture, News newsWindow)
        {
            InitializeComponent();
            selectedCulture = culture;
            this.newsWindow = newsWindow;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            ApplyLanguageResources();
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
            AddButton.Content = FindResource("AddNews").ToString();                               
            CancelButton.Content = FindResource("Exit").ToString();                        
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            string description = DescriptionTextBox.Text;
            string date = DateTime.Now.ToString("dd.MM.yyyy");

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            // Добавляем новость в основное окно новостей
            NewsItem newNewsItem = new NewsItem { Title = title, Description = description, Date = date };
            newsWindow.NewsPanel.Children.Add(newsWindow.CreateNewsItem(newNewsItem));

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
