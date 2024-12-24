using CarDealership.Commands;
using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using CarDealership.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarDealership.ViewModels
{
    internal class CarListViewModel : ViewModelBase
    {
        private IModificationRepository modificationRepository;
        private IBookingRepository bookingRepository;
        private ICustomerRepository userRepository;
        private ICarRepository carRepository;

        private List<ModificationDTO> allModifications;

        public List<ModificationDTO> AllModifications
        {
            get => allModifications;
            set
            {
                allModifications = value;
                OnPropertyChanged(nameof(AllModifications));
            }
        }

        private string filterInfo;

        public string FilterInfo
        {
            get => filterInfo;
            set
            {
                filterInfo = value;
                OnPropertyChanged(nameof(FilterInfo));
            }
        }

        public ICommand BookingCommand { get; set; }
        public ICommand ApplyCarFilterCommand { get; set; }

        public CarListViewModel()
        {
            modificationRepository = new ModificationRepository();
            bookingRepository = new BookingRepository();
            userRepository = new CustomerRepository();
            carRepository = new CarRepository();

            AllModifications = modificationRepository.GetAll();

            BookingCommand = new RelayCommand(OnBookingCommandExecuted, CanBookingCommandExecute);
            ApplyCarFilterCommand = new RelayCommand(OnApplyCarFilterCommandExecuted);
        }

        private bool CanBookingCommandExecute(object p)
        {
            if (p is ModificationDTO mod)
            {
                //return modificationRepository.GetStockQuantity(mod.Id) >= 1;
                return modificationRepository.GetAvailableCount(mod.Id) >= 1;
            }
            return false;
        }

        private void OnBookingCommandExecuted(object p)
        {
            if (p is ModificationDTO mod)
            {
                int customer_id = userRepository.GetCurrentCustomer().Id;
                int car_id = carRepository.GetAvailableByModification(mod.Id).Id;

                if (bookingRepository.GetCountOpenBookingsByCustomerId(customer_id) == 2)
                {
                    MessageBox.Show("Вы можете забронаровать только 2 автомобиля");
                    return;
                }

                if (!bookingRepository.IsBookingAvailable(customer_id, car_id)) {
                    MessageBox.Show("Вы уже забронировали данную модификацию");
                    return;
                }
                
                BookingDTO booking = new();

                booking.CustomerId = customer_id;
                booking.CarId = car_id;
                booking.Date = DateOnly.FromDateTime(DateTime.Now);

                bookingRepository.AddBooking(booking);  
            }
        }

        private void OnApplyCarFilterCommandExecuted(object p)
        {
            CarFilterWindowViewModel vm = new();
            CarFilterWindow window = new(vm);
            if (window.ShowDialog() == false) return;

            var mods = modificationRepository.GetByFilter(vm.SelectedCarBrand, vm.SelectedEngineType, vm.SelectedTransmissionType, vm.SelectedBodyType, vm.IsAvailableOnly);
            AllModifications = mods;
            FilterInfo = vm.GetFilterInfo();
        }
    }
}
