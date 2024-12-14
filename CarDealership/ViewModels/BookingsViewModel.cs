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

        public BookingsViewModel()
        {
            bookingRepo = new BookingRepository();
            userRepo = new CustomerRepository();
            carRepository = new CarRepository();
            sellerRepository = new SellerRepository();
            saleRepository = new SaleRepository();

            Bookings = bookingRepo.GetAll();

            CancelBooking = new RelayCommand(OnCancelBookingExecuted);
            MakeBooking = new RelayCommand(OnMakeBookingExecuted);
        }

        private void OnCancelBookingExecuted(object p)
        {
            if (p is BookingDTO booking)
            {
                var res = MessageBox.Show("Отменить бронирование?", "Подтвердить действие", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    bookingRepo.Delete(booking.Id);
                    Bookings.Remove(booking);
                }
            }
        }

        private void OnMakeBookingExecuted(object p)
        {
            if (p is BookingDTO booking)
            {
                MakeSaleWindow w = new();

                MakeSaleViewModel vm = new();

                var customer = userRepo.GetByID(booking.CustomerId);
                var car = carRepository.GetById(booking.CarId);
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

                bookingRepo.Delete(booking.Id);

                saleRepository.Add(sale);

                Bookings = bookingRepo.GetAll();

            }
        }
    }
}
