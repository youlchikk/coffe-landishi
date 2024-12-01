using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using coffe_app.logic; // Подключаем ваше пространство имен
using MenuDLL;

namespace coffe_app
{
    public partial class Promotions : Window
    {
        private string selectedCulture;
        private MainWindow mainWindow;
       // private List<Promotion> promotions; // Список акций

        public Promotions(string culture, MainWindow mainWindow)
        {
            InitializeComponent();
            selectedCulture = culture;
            this.mainWindow = mainWindow;
            this.Language = XmlLanguage.GetLanguage(selectedCulture);
            ApplyLanguageResources();
            LoadPromotions();
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
            PromotionsLabel.Content = FindResource("Promotions").ToString();
            BackToMainButton.Content = FindResource("Back").ToString();
            ExitButton.Content = FindResource("Exit").ToString();
        }

        private void LoadPromotions()
        {
            // Пример создания объектов Promotion и их добавления в список
          //  promotions = new List<Promotion>
            {
              //  new Promotion { conditions = "Скидка 10% Скидка на все напитки до конца месяца!", price = 9.9, startDate = "01.01.2025", endtDate = "31.01.2025" },
               // new Promotion { conditions = "2 по цене 1  Купите один кофе и получите второй бесплатно!", price = 5, startDate = "01.02.2025", endtDate = "28.02.2025" },
            };

          //  foreach (var promotion in promotions)
            {
          //      PromotionsListBox.Items.Add(CreatePromotionItem(promotion));
            }
        }

        private ListBoxItem CreatePromotionItem(Promotion promotion)
        {
            var stackPanel = new StackPanel { Orientation = Orientation.Vertical, Margin = new Thickness(5) };

            var titleBlock = new TextBlock
            {
                Text = promotion.conditions,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            };

            var descriptionBlock = new TextBlock
            {
              //  Text = promotion.price,
                FontSize = 14,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            var dateBlock = new TextBlock
            {
                Text = $"Период действия: с {promotion.startDate} по {promotion.endtDate}",
                FontSize = 12,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            stackPanel.Children.Add(titleBlock);
            stackPanel.Children.Add(descriptionBlock);
            stackPanel.Children.Add(dateBlock);

            return new ListBoxItem { Content = stackPanel, Tag = promotion };
        }

        private void AddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (PromotionsListBox.SelectedItem is ListBoxItem selectedItem)
            {
                var selectedPromotion = selectedItem.Tag as Promotion;
                // Логика добавления акции в заказ
                MessageBox.Show($"Акция \"{selectedPromotion.conditions}\" добавлена в заказ.");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите акцию.");
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
