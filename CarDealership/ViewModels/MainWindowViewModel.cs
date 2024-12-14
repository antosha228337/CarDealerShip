using System.Windows.Controls;
using CarDealership.Views;
using System.Windows.Input;
using CarDealership.Commands;

namespace CarDealership.ViewModels
{
    class MainWindowViewModel : ViewModelBase
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


        public ICommand ShowUserViewCommand { get; set; }
        public ICommand ShowCarsViewCommand { get; set; }

        public MainWindowViewModel()
        {
            CurrentView = new AboutUserView();

            ShowUserViewCommand = new RelayCommand(OnShowUserViewCommandExecuted);
            ShowCarsViewCommand = new RelayCommand(OnShowCarsViewCommandExecuted);  
        }

        private void OnShowUserViewCommandExecuted(object p)
        {
            CurrentView = new AboutUserView();
        }

        private void OnShowCarsViewCommandExecuted(object p)
        {
            CurrentView = new CarListView();
        }

    }
}
