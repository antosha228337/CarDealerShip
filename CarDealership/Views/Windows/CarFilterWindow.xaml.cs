using CarDealership.ViewModels;
using System.Windows;

namespace CarDealership.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для CarFilterWindow.xaml
    /// </summary>
    public partial class CarFilterWindow : Window
    {
        public CarFilterWindow(CarFilterWindowViewModel view)
        {
            DataContext = view;
            InitializeComponent();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
