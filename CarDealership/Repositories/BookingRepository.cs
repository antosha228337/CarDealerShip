using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using DAL;

namespace CarDealership.Repositories
{
    class BookingRepository : IBookingRepository
    {

        CarDealershipMainContext db = new();

        public BookingRepository()
        {
            db.Bookings.Include(b => b.StatusType).Include(b => b.Car).ThenInclude(c => c.Modification).ThenInclude(m => m.Model).ThenInclude(m => m.CarBrand).Include(b => b.Customer).ToList();
        }

        public List<BookingDTO> GetBookingsByCustomerId(int customer_id)
        {
            return db.Bookings.Include(b => b.StatusType).Include(b => b.Car).ThenInclude(c => c.Modification).ThenInclude(m => m.Model).ThenInclude(m => m.CarBrand).Include(b => b.Customer).Where(b => b.CustomerId == customer_id).Select(i => new BookingDTO(i)).ToList();
        }

        public bool IsBookingAvailable(int customerId, int carId)
        {
            var car = db.Cars.Find(carId);

            if (car != null)
            {
                return !db.Bookings.Where(b => b.CustomerId == customerId && b.Car.ModificationId == car.ModificationId && (b.StatusTypeId == 1 || b.StatusTypeId == 3)).Any();
            }
            return false;
            
        }

        public List<BookingDTO> GetAll()
        {
            return db.Bookings.Include(b => b.StatusType).Include(b => b.Car).ThenInclude(c => c.Modification).ThenInclude(m => m.Model).ThenInclude(m => m.CarBrand).Include(b => b.Customer).Select(i => new BookingDTO(i)).ToList();
        }

        public void AddBooking(BookingDTO booking) 
        {
            db.Bookings.Add(new Booking()
            {
                StatusTypeId = 1,
                CustomerId = booking.CustomerId,
                CarId = booking.CarId,
                Date = booking.Date,
            });
            db.SaveChanges();
        }

        public void Delete(int id) 
        {
            var b = db.Bookings.Find(id);

            if (b != null)
            {
                db.Bookings.Remove(b);
                db.SaveChanges();
            }
        }

        public int GetCountOpenBookingsByCustomerId(int id)
        {
            return db.Bookings.Count(b => b.CustomerId == id && (b.StatusTypeId == 1 || b.StatusTypeId == 3));
        }

        public int GetCountBookingsByCustomerId(int id)
        {
            return db.Bookings.Count(b => b.CustomerId == id);
        }

        public void Update(BookingDTO booking)
        {
            var b = db.Bookings.Find(booking.Id);

            if (b != null)
            {
                //b.Date = booking.Date;
                b.StatusTypeId = booking.StatusId;
                db.SaveChanges();
            }
        }
    }
}
