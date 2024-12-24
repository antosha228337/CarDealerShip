using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using CarDealership.DTO;
using System.Windows.Input;
using System.Windows;
using CarDealership.Commands;
using CarDealership.Views.Windows;

namespace CarDealership.ViewModels
{
    internal class BookingsViewModel : ViewModelBase
    {
        IBookingRepository bookingRepo;
        ICustomerRepository userRepo;
        ICarRepository carRepository;
        ISellerRepository sellerRepository;
        ISaleRepository saleRepository;

        public ICommand CancelBooking {  get; set; }
        public ICommand MakeBooking { get; set; }
        public ICommand ConfirmBookingCommand { get; set; }

        private List<BookingDTO> bookings;

        public List<BookingDTO> Bookings
        {
            get => bookings;
            set
            {
                bookings = value;
                OnPropertyChanged(nameof(Bookings));
            }
        }

        private BookingDTO? selectedBooking;

        public BookingDTO? SelectedBooking
        {
            get => selectedBooking;
            set
            {
                selectedBooking = value;
                OnPropertyChanged(nameof(SelectedBooking));
            }
        }

        public BookingsViewModel()
        {
            bookingRepo = new BookingRepository();
            userRepo = new CustomerRepository();
            carRepository = new CarRepository();
            sellerRepository = new SellerRepository();
            saleRepository = new SaleRepository();

            Bookings = bookingRepo.GetAll();

            CancelBooking = new RelayCommand(OnCancelBookingExecuted, CanCancelBookingExecute);
            MakeBooking = new RelayCommand(OnMakeBookingExecuted, CanMakeBookingExecute);
            ConfirmBookingCommand = new RelayCommand(OnConfirmBookingCommandExecuted, CanConfirmBookingCommandExecute);
        }

        private bool CanCancelBookingExecute(object p)
        {
            return selectedBooking != null && selectedBooking.StatusId == 1;
        }

        private void OnCancelBookingExecuted(object p)
        {
            if (selectedBooking != null)
            {
                var res = MessageBox.Show("Отменить бронирование?", "Подтвердить действие", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                   selectedBooking.StatusId = 2;
                    bookingRepo.Update(selectedBooking);
                }
            }
        }

        private bool CanMakeBookingExecute(object p)
        {
            return selectedBooking != null && selectedBooking.StatusId == 3;
        }

        private void OnMakeBookingExecuted(object p)
        {
            if (selectedBooking != null)
            {
                MakeSaleWindow w = new();

                MakeSaleViewModel vm = new();

                var customer = userRepo.GetByID(selectedBooking.CustomerId);
                var car = carRepository.GetById(selectedBooking.CarId);
                var seller = sellerRepository.GetCurrentSeller();

                vm.CustomerFIO = customer.LastName + " " + customer.FisrtName + " " + customer.ThirdName;
                vm.CustomerPN = customer.PhoneNumber;

                vm.CarVIN = car.Vin;
                vm.CarBrand = car.Brand;
                vm.CarModel = car.ModelName;
                vm.CarModification = car.ModificationName;
                vm.CarPrice = car.CarPrice;
                vm.CarImage = car.Image;
                vm.SellerFIO = seller.LastName + " " + seller.FirstName + " " + seller.ThirdName;

                w.DataContext = vm;

                if (w.ShowDialog() == false) return;

                SaleDTO sale = new();
                sale.SaleDate = DateOnly.FromDateTime(DateTime.Now);

                sale.TotalPrice = vm.TotalPrice;
                sale.CarPrice = vm.CarPrice;
                sale.CustomerId = customer.Id;
                sale.SellerId = seller.Id;
                sale.CarId = car.Id;
                sale.CreditId = vm.SelectedCredit?.Id;
                sale.Services = vm.SelectedServices;

                selectedBooking.StatusId = 4;

                bookingRepo.Update(selectedBooking);

                saleRepository.Add(sale);

                Bookings = bookingRepo.GetAll();

            }
        }

        private bool CanConfirmBookingCommandExecute(object p)
        {
            return selectedBooking != null && selectedBooking.StatusId == 1;
        }

        private void OnConfirmBookingCommandExecuted(object p)
        {
            if (selectedBooking != null)
            {
                var res = MessageBox.Show("Подтвердить бронирование бронирование?", "Подтвердить действие", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    selectedBooking.StatusId = 3;
                    bookingRepo.Update(selectedBooking);
                }
            }
        }
    }
}
