using DAL;

namespace CarDealership.DTO
{
    class BookingDTO
    { 
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public int StatusId { get; set; }


        public string Status { get; set; }

        public string CarBrand { get; set; }

        public string CarModel { get; set; }

        public string CarModification {  get; set; }

        public string CarVin {  get; set; }

        public int CarPrice { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerPhone { get; set; }

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
            StatusId = booking.StatusTypeId;

            CustomerFirstName = booking.Customer.FisrtName;
            CustomerLastName = booking.Customer.LastName;
            CustomerPhone = booking.Customer.PhoneNumber;
            Status = booking.StatusType.Name;
        }
    }
}
