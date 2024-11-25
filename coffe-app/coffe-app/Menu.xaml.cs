using System;
using System.Windows;
using System.Windows.Controls;
using MenuDLL; // Подключаем библиотеку MenuDLL

namespace coffe_app
{
    public partial class Menu : Window
    {
        private MainWindow mainWindow;

        public Menu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            // Пример добавления элементов меню
            var americano = new Americano();
            americano.createWithChocolateSyrup(); // Вызываем метод для создания кофе с шоколадным сиропом

            MenuItemsPanel.Children.Add(CreateMenuItem("Американо с шоколадным сиропом", 2.5));
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

            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(priceBlock);

            return stackPanel;
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
