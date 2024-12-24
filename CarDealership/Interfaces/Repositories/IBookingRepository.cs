using CarDealership.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Interfaces.Repositories
{
    interface IBookingRepository
    {
        public List<BookingDTO> GetBookingsByCustomerId(int customer_id);

        public int GetCountOpenBookingsByCustomerId(int id);

        public int GetCountBookingsByCustomerId(int id);

        public void AddBooking(BookingDTO booking);

        public void Delete(int id);

        public List<BookingDTO> GetAll();

        public bool IsBookingAvailable(int customerId, int modId);

        public void Update(BookingDTO booking);

    }
}
