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

        public void AddBooking(BookingDTO booking);

        public void Delete(int id);
    }
}
