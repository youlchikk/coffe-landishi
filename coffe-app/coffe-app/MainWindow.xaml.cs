using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

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
            TrackOrderButton.Content = FindResource("TrackOrder").ToString();
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
            // Логика для открытия окна изменения статуса заказа
        }
        private void Statistics_Click(object sender, RoutedEventArgs e) 
        { 
            // Логика для открытия окна статистики
        } private void AddPromotion_Click(object sender, RoutedEventArgs e) 
        { 
            // Логика для открытия окна добавления акций
        }
        private void EditMenu_Click(object sender, RoutedEventArgs e) 
        { 
            // Логика для открытия окна редактирования меню
        }
        private void OpenProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profileWindow = new Profile(selectedCulture, this, username);
            profileWindow.Show();
            this.Hide();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Menu menuWindow = new Menu(selectedCulture, this);
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
