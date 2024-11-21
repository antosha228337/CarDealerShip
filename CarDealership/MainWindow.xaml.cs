using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarDealership.Views.Windows;

namespace CarDealership
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonFilterClick(object sender, RoutedEventArgs e)
        {
            CarFilterWindow window = new CarFilterWindow();
            if (window.ShowDialog() == false) return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CarAboutWindow window = new();
            if (window.ShowDialog() == false) return;
        }
    }
}