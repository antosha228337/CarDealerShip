﻿using CarDealership.Commands;
using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarDealership.ViewModels
{
    internal class AboutUserViewModel : ViewModelBase
    {

        private CustomerDTO customer;

        private ICustomerRepository userRepo;
        private IBookingRepository bookingRepo;
        private ISaleRepository saleRepo;
        
        
        public ICommand CancelBooking {  get; set; }

        public CustomerDTO Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        private List<BookingDTO> bookings;

        public ObservableCollection<BookingDTO> Bookings
        {
            get;
            set;
            
        }

        private List<SaleDTO> sales;

        public List<SaleDTO> Sales
        {
            get => sales;
            set
            {
                sales = value;
                OnPropertyChanged(nameof(Sales));
            }
        }


        public AboutUserViewModel()
        {
            userRepo = new CustomerRepository();
            bookingRepo = new BookingRepository();
            saleRepo = new SaleRepository();

            Customer = userRepo.GetCurrentCustomer();
            Bookings = new(bookingRepo.GetBookingsByCustomerId(Customer.Id));

            CancelBooking = new RelayCommand(OnCancelBookingExecuted);
            Sales = saleRepo.GetAll();
        }

        public void OnCancelBookingExecuted(object p)
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
    }
}
