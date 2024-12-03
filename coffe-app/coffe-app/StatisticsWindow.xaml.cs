using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace coffe_app
{
    public partial class StatisticsWindow : Window
    {
        private MainWindow mainWindow;
        private string selectedCulture;

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
            // Здесь будет код для загрузки статистики из Archive.xlsx
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

