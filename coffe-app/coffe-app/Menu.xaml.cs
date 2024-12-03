using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MenuDLL; // Используем класс Menu из MenuDLL
using coffe_app.logic;
using System.Windows.Markup;

namespace coffe_app
{
    public partial class Menu : Window
    {
        private string selectedCulture;
        private MainWindow mainWindow;
        private List<Order> orders = new List<Order>();
        private Order currentOrder;
        private string username; // добавляем поле для имени пользователя

        public Menu(string culture, MainWindow mainWindow, string username) // добавляем username в конструктор
        {
            InitializeComponent();
            selectedCulture = culture;
            this.mainWindow = mainWindow;
            this.username = username; // сохраняем имя пользователя
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
                MenuItemsPanel.Children.Add(CreateMenuItem(item));
            }
        }

        private UIElement CreateMenuItem(MenuDLL.Menu menuItem)
        {
            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

            var textBlock = new TextBlock
            {
                Text = menuItem.description,
                FontSize = 18,
                VerticalAlignment = VerticalAlignment.Center
            };

            var priceBlock = new TextBlock
            {
                Text = $"{menuItem.price} рублей",
                FontSize = 18,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 0, 0)
            };

            var addButton = new Button
            {
                Content = "Добавить",
                Margin = new Thickness(10, 0, 0, 0),
                Background = new SolidColorBrush(Color.FromRgb(245, 172, 255)), // Цвет фона
                BorderBrush = new SolidColorBrush(Color.FromRgb(236, 183, 255)), // Цвет границы
                FontFamily = new FontFamily("Monotype Corsiva"), // Шрифт
                FontSize = 18 // Размер шрифта
            };
            addButton.Click += (sender, e) => AddToOrder(menuItem);

            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(priceBlock);
            stackPanel.Children.Add(addButton);

            return stackPanel;
        }

        private void AddToOrder(MenuDLL.Menu menuItem)
        {
            if (currentOrder == null)
            {
                currentOrder = new Order(username, 0, new List<MenuDLL.Menu>()); // используем username
            }

            currentOrder.components.Add(menuItem);
            currentOrder.price += menuItem.price;

            MessageBox.Show($"{menuItem.description} добавлен в заказ по цене {menuItem.price} рублей");
        }

        private void OrderWindow_Click(object sender, RoutedEventArgs e)
        {
            if (currentOrder != null)
            {
                orders.Add(currentOrder);
                currentOrder = null; // Создаем новый заказ после добавления текущего
            }

            var orderWindow = new OrderWindow(orders, mainWindow, selectedCulture, username);
            orderWindow.Show();
            this.Close();
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
