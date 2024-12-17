using CarDealership.Commands;
using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CarDealership.ViewModels
{
    public class MakeSaleViewModel : ViewModelBase
    {
        private IServiceRepository serviceRepository;
        private ICreditRepository creditRepository;

        private List<ServiceDTO> selectedServices = new();

        public List<ServiceDTO> SelectedServices
        {
            get => selectedServices;
        }

        #region Свойства

        public List<ServiceDTO> Services  => serviceRepository.GetAll();

        public List<CreditDTO> Credits => creditRepository.GetAll();

        private CreditDTO? selectedCredit;

        public CreditDTO? SelectedCredit
        {
            get => selectedCredit;
        }


        private int overPayment;

        public int OverPayment
        {
            get => overPayment;
            set
            {
                overPayment = value;
                OnPropertyChanged(nameof(OverPayment));
            }
        }

        private int servicesPrice;

        public int ServicesPrice
        {
            get => servicesPrice;
            set
            {
                servicesPrice = value;
                OnPropertyChanged(nameof(ServicesPrice));
            }
        }

        private double monthPayment;

        public double MonthPayment
        {
            get => monthPayment;
            set
            {
                monthPayment = value;
                OnPropertyChanged(nameof(MonthPayment));
            }
        }

        private int totalPrice;

        public int TotalPrice
        {
            get => totalPrice;
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private bool useCredit;

        public bool UseCredit
        {
            get => useCredit;
            set
            {
                useCredit = value;
                if (useCredit == false) TotalPrice = carPrice;
                else if (selectedCredit != null)
                {
                    float monthlyInterestRate = selectedCredit.InterestRate / 100 / 12;
                    double monthlyPayment = (carPrice * monthlyInterestRate) /
                                    (1 - Math.Pow(1 + monthlyInterestRate, -selectedCredit.Period * 12));
                    double totalCost = monthlyPayment * selectedCredit.Period * 12;
                    TotalPrice = (int)totalCost;
                }

                OnPropertyChanged(nameof(UseCredit));
            }
        }

        private string customerFIO;

        public string CustomerFIO
        {
            get => customerFIO;
            set
            {
                customerFIO = value;
                OnPropertyChanged(nameof(CustomerFIO));
            }
        }

        private string customerPN;

        public string CustomerPN
        {
            get => customerPN;
            set
            {
                customerPN = value;
                OnPropertyChanged(nameof(CustomerPN));
            }
        }

        private string sellerFIO;

        public string SellerFIO
        {
            get => sellerFIO;
            set
            {
                sellerFIO = value;
                OnPropertyChanged(nameof(SellerFIO));
            }
        }

        private string carBrand;

        public string CarBrand
        {
            get => carBrand;
            set
            {
                carBrand = value;
                OnPropertyChanged(nameof(CarBrand));
            }
        }

        private string carModel;

        public string CarModel
        {
            get => carModel;
            set
            {
                carModel = value;
                OnPropertyChanged(nameof(CarModel));
            }
        }

        private string carModification;

        public string CarModification
        {
            get => carModification;
            set
            {
                carModification = value;
                OnPropertyChanged(nameof(CarModification));
            }
        }

        private string carVIN;

        public string CarVIN
        {
            get => carVIN;
            set
            {
                carVIN = value;
                OnPropertyChanged(nameof(CarVIN));
            }
        }

        private int carPrice;

        public int CarPrice
        {
            get => carPrice;
            set
            {
                carPrice = value;
                TotalPrice = CarPrice;
                OnPropertyChanged(nameof(CarPrice));
            }
        }

        private BitmapImage carImage;

        public BitmapImage CarImage
        {
            get => carImage;
            set
            {
                carImage = value;
                OnPropertyChanged(nameof(CarImage));
            }
        }
        #endregion

        #region Команды

        public ICommand ChangeCreditCommand { get; set; }
        public ICommand AddServiceCommand { get; set; }

        #endregion

        public MakeSaleViewModel()
        {
            serviceRepository = new ServiceRepository();
            creditRepository = new CreditRepository();

            ChangeCreditCommand = new RelayCommand(OnChangeCreditCommandExecuted);
            AddServiceCommand = new RelayCommand(OnAddServiceCommandExecuted);

        }

        private void OnChangeCreditCommandExecuted(object p)
        {
            if (p is CreditDTO credit)
            {

                selectedCredit = credit;

                float monthlyInterestRate = credit.InterestRate / 100 / 12;


                double monthlyPayment = (carPrice * monthlyInterestRate) /
                                (1 - Math.Pow(1 + monthlyInterestRate, -credit.Period * 12));

                double totalCost = monthlyPayment * credit.Period * 12;

                TotalPrice = (int)totalCost;
                OverPayment = TotalPrice - carPrice;
                MonthPayment = Math.Round(monthlyPayment, 2);
            }
        }

        private void OnAddServiceCommandExecuted(object p)
        {
            if (p is ServiceDTO service)
            {
                if (!selectedServices.Remove(service)) selectedServices.Add(service);
                int total_price = 0;

                for (int i =0; i != selectedServices.Count; i++)
                {
                    total_price += selectedServices[i].Price;
                }
                ServicesPrice = total_price;
            }
        }
    }
}
