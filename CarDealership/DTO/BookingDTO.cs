using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DTO
{
    class BookingDTO
    { 
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public string CarModification {  get; set; }

        public string CarVin {  get; set; }

        public int CarPrice { get; set; }

        public BookingDTO()
        {
            
        }

        public BookingDTO(Booking booking)
        {
            Id = booking.Id;
            Date = booking.Date;
            CarId = booking.CarId;
            CustomerId = booking.CustomerId;
            CarBrand = booking.Car.Modification.Model.CarBrand.Name;
            CarModel = booking.Car.Modification.Model.Name;
            CarModification = booking.Car.Modification.Name;
            CarPrice = booking.Car.Modification.Price;
            CarVin = booking.Car.Vin;
        }
    }
}
