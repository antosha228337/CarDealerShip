using CarDealership.Commands;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using CarDealership.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarDealership.ViewModels
{
    class LoginWindowViewModel : ViewModelBase
    {
       
        private string _password;
        private string _login;
        private string _errorMessage;

        IUserRepository userRepo;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                ErrorMessage = "";
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                ErrorMessage = "";
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand ExitCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public LoginWindowViewModel()
        {
            _errorMessage = "";
            userRepo = new UserRepository();

            ExitCommand = new RelayCommand(OnExitCommandExecuted, CanExitCommandExecute);
            LoginCommand = new RelayCommand(OnLoginCommandExecuted, CanLoginCommandExecute);
        }

        private void OnExitCommandExecuted(object p) => Application.Current.MainWindow.Close();

        private bool CanExitCommandExecute(object p) => true;

        private void OnLoginCommandExecuted(object p)
        {
            if (userRepo.CheckUserExistence(new System.Net.NetworkCredential(Login, Password)))
            {

                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Login), null);
                MainWindow w = new();
                w.Show();

                var login_window = Application.Current.Windows.OfType<LoginWindow>().First();
                login_window?.Close();
            }
            else
            {
                ErrorMessage = "Не верный логин или пароль!";
            }
        }

        private bool CanLoginCommandExecute(object p) => true;
    }
}
