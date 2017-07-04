using DailyFeed.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DailyFeed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new GeneralViewModel();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            rect.Visibility = System.Windows.Visibility.Collapsed;
            MainButton.Content = ">";
            tabView.Visibility = System.Windows.Visibility.Collapsed;
            gridCol1.Visibility = System.Windows.Visibility.Collapsed;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rect.Visibility == System.Windows.Visibility.Collapsed)
            {
                rect.Visibility = System.Windows.Visibility.Visible;
                (sender as Button).Content = "<";
                tabView.Visibility = System.Windows.Visibility.Visible;
                gridCol1.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                rect.Visibility = System.Windows.Visibility.Collapsed;
                (sender as Button).Content = ">";
                tabView.Visibility = System.Windows.Visibility.Collapsed;
                gridCol1.Visibility = System.Windows.Visibility.Collapsed;
            }
        }


    }
}
