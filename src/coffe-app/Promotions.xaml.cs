using MenuDLL;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using coffe_app.logic; // Подключаем ваше пространство имен

namespace coffe_app
{
    public partial class Promotions : Window
    {
        private string selectedCulture;
        private MainWindow mainWindow;
        private List<Promotion> promotions; // Список акций

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
            // Загружаем акции из UserPromotions
            UserPromotions userPromotions = new UserPromotions();
            promotions = userPromotions.components;

            foreach (var promotion in promotions)
            {
                PromotionsListBox.Items.Add(CreatePromotionItem(promotion));
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
                Text = $"{promotion.price} рублей",
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
                for (int i = 0; i < promotions.Count; i++)
                {
                    if (promotions[i].conditions == selectedPromotion.conditions)
                    {
                        MessageBox.Show($"Акция \"{selectedPromotion.conditions}\" добавлена в заказ.");
                        MainWindow.CurrentOrder.addPromotion(promotions[i]); // Добавляем акцию в текущий заказ
                    }
                }
               
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
