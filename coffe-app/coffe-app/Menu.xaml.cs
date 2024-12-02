using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MenuDLL;
using coffe_app.logic;

namespace coffe_app
{
    public partial class Menu : Window
    {
        private string selectedCulture;
        private MainWindow mainWindow;

        public Menu(string culture, MainWindow mainWindow)
        {
            InitializeComponent();
            selectedCulture = culture;
            this.mainWindow = mainWindow;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            ApplyLanguageResources();
            LoadMenuItems();
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
            MenuLabel.Content = FindResource("Menu").ToString();
            OrderWindowButton.Content = FindResource("OrderWindow").ToString();
            ExitButton.Content = FindResource("Exit").ToString();
            BackToMainButton.Content = FindResource("Back").ToString();
        }

        private void LoadMenuItems()
        {
            UserMenu userMenu = new UserMenu();

            foreach (var item in userMenu.components)
            {
                MenuItemsPanel.Children.Add(CreateMenuItem(item.description, item.price));
            }
        }

        private UIElement CreateMenuItem(string description, double price)
        {
            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

            var textBlock = new TextBlock
            {
                Text = description,
                FontSize = 18,
                VerticalAlignment = VerticalAlignment.Center
            };

            var priceBlock = new TextBlock
            {
                Text = $"{price} рублей",
                FontSize = 18,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var addButton = new Button
            {
                Content = "Добавить",
                Margin = new Thickness(10, 0, 0, 0)
            };
            addButton.Click += (sender, e) => AddToOrder(description, price);

            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(priceBlock);
            stackPanel.Children.Add(addButton);

            return stackPanel;
        }

        private void AddToOrder(string description, double price)
        {
            // Логика для добавления элемента в заказ
            MessageBox.Show($"{description} добавлен в заказ по цене {price} рублей");
        }

        private void OrderWindow_Click(object sender, RoutedEventArgs e)
        {
            // Логика для перехода к окну заказа
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
