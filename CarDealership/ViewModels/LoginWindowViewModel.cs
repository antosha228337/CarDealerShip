using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarDealership.Views;
using System.Windows.Controls;
using System.Windows.Input;
using CarDealership.Commands;

namespace CarDealership.ViewModels
{
    internal class LoginWindowViewModel : ViewModelBase
    {
        private UserControl currentView;

        public UserControl CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        private string switchButtonText;

        public string SwitchButtonText
        {
            get => switchButtonText;
            set
            {
                switchButtonText = value;
                OnPropertyChanged(nameof(SwitchButtonText));
            }
        }

        public ICommand ChangeViewCommand { get; set; }

        public LoginWindowViewModel()
        {
            CurrentView = new LoginView();
            SwitchButtonText = "Зарегистрироваться";

            ChangeViewCommand = new RelayCommand(OnChangeViewCommandExecuted);
        }

        private void OnChangeViewCommandExecuted(object p)
        {
            if (currentView is LoginView)
            {
                CurrentView = new RegistrationView();
                SwitchButtonText = "Войти";
            }
            else if (currentView is RegistrationView)
            {
                CurrentView = new LoginView();
                SwitchButtonText = "Зарегистрироваться";
            }
        }
    }
}
