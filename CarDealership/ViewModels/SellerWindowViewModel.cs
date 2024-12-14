using CarDealership.Commands;
using CarDealership.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace CarDealership.ViewModels
{
    internal class SellerWindowViewModel : ViewModelBase
    {
        private UserControl current_view;

        public UserControl CurrentView
        {
            get => current_view;
            set
            {
                current_view = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand ShowDataStorageCommand { get; set; }
        public ICommand ShowBookingViewCommand { get; set; }
        public ICommand ShowSalesCommand { get; set; }

        public SellerWindowViewModel()
        {
            CurrentView = new DataStorageView();

            ShowDataStorageCommand = new RelayCommand(OnShowDataStorageCommandExecuted);
            ShowBookingViewCommand = new RelayCommand(OnShowBookingViewCommandExecuted);
            ShowSalesCommand = new RelayCommand(OnShowSalesCommandExecuted);
        }

        private void OnShowDataStorageCommandExecuted(object p)
        {
            CurrentView = new DataStorageView();
        }

        private void OnShowBookingViewCommandExecuted(object p)
        {
            CurrentView = new BookingsView();
        }

        private void OnShowSalesCommandExecuted(object p)
        {
            CurrentView = new SalesView();
        }
    }
}
