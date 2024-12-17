﻿using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    class BookingRepository : IBookingRepository
    {

        CarDealershipMainContext db = new();

        public BookingRepository()
        {
            db.Bookings.Include(b => b.Car).ThenInclude(c => c.Modification).ThenInclude(m => m.Model).ThenInclude(m => m.CarBrand).Include(b => b.Customer).ToList();
        }

        public List<BookingDTO> GetBookingsByCustomerId(int customer_id)
        {
            return db.Bookings.Where(b => b.CustomerId == customer_id).Select(i => new BookingDTO(i)).ToList();
        }

        public bool IsBookingAvailable(int customerId, int carId)
        {
            var car = db.Cars.Find(carId);

            if (car != null)
            {
                return !db.Bookings.Where(b => b.CustomerId == customerId && b.Car.ModificationId == car.ModificationId).Any();
            }
            return false;
            
        }

        public List<BookingDTO> GetAll()
        {
            return db.Bookings.Select(i => new BookingDTO(i)).ToList();
        }

        public void AddBooking(BookingDTO booking) 
        {
            db.Bookings.Add(new Booking()
            {
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

        public int GetCountBookingsByCustomerId(int id)
        {
            return db.Bookings.Count(b => b.CustomerId == id);
        }
    }
}
