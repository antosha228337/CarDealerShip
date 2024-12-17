using CarDealership.Commands;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using CarDealership.Views.Windows;
using System.Security.Principal;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Controls;
using CarDealership.DTO;

namespace CarDealership.ViewModels
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace((value ?? "").ToString()))
                return new ValidationResult(false, "Поле не может быть пустым");

            return ValidationResult.ValidResult;
        }
    }

    internal class RegistrationViewModel : ViewModelBase
    {

        private string password;
        private string login;
        private string errorMessage;
        private string userName;
        private string userLastName;
        private string userThirdName;
        private string userPhoneNumber;

        ICustomerRepository userRepo;
        ISellerRepository sellerRepo;

        public string Login
        {
            get => login;
            set
            {
                login = value;
                ErrorMessage = "";
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                ErrorMessage = "";
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string UserLastName
        {
            get => userLastName;
            set
            {
                userLastName = value;
                OnPropertyChanged(nameof(UserLastName));
            }
        }

        public string UserThirdName
        {
            get => userThirdName;
            set
            {
                userThirdName = value;
                OnPropertyChanged(nameof(UserThirdName));
            }
        }

        public string UserPhoneNumber
        {
            get => userPhoneNumber;
            set
            {
                userPhoneNumber = value;
                OnPropertyChanged(nameof(UserPhoneNumber));
            }
        }

        public ICommand LoginCommand { get; set; }

        public RegistrationViewModel()
        {
            errorMessage = "";
            userRepo = new CustomerRepository();
            sellerRepo = new SellerRepository();
            LoginCommand = new RelayCommand(OnLoginCommandExecuted, CanLoginCommandExecute);
        }

        private void OnLoginCommandExecuted(object p)
        {
            
            if (!CheckInputData())
            {
                ErrorMessage = "Все поля должны быть заполнены";
                return;
            }
            
            if (userRepo.CheckAvailableLogin(login))
            {
                CustomerDTO customer = new()
                {
                    FisrtName = userName,
                    LastName = userLastName,
                    PhoneNumber = userPhoneNumber,
                    ThirdName = userThirdName,
                    Login = login,
                    Password = password
                };

                userRepo.Add(customer);

                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(login), ["Customer"]);

                MainWindow w = new();
                w.Show();

                var login_window = Application.Current.Windows.OfType<LoginWindow>().First();
                login_window?.Close();
            }
            else
            {
                ErrorMessage = "Пользователь с таким логином уже существует";
            }

            //if (userRepo.CheckUserExistence(new System.Net.NetworkCredential(Login, Password)))
            //{



            //    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Login), ["Customer"]);

            //    MainWindow w = new();
            //    w.Show();

            //    var login_window = Application.Current.Windows.OfType<LoginWindow>().First();
            //    login_window?.Close();
            //}
            //else if (sellerRepo.CheckUserExistence(new System.Net.NetworkCredential(Login, Password)))
            //{
            //    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Login), ["Seller"]);

            //    SellerMainWindow w = new();
            //    w.Show();

            //    var login_window = Application.Current.Windows.OfType<LoginWindow>().First();
            //    login_window?.Close();
            //}
            //else
            //{
            //    ErrorMessage = "Не верный логин или пароль!";
            //}
        }

        private bool CanLoginCommandExecute(object p) => true;
       
        private bool CheckInputData()
        {
            return !(string.IsNullOrWhiteSpace(login) && string.IsNullOrWhiteSpace(password) &&
               string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(userLastName) &&
               string.IsNullOrWhiteSpace(userPhoneNumber));
        }
    }
}
