using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    internal class CarRepository : ICarRepository
    {
        CarDealershipMainContext db = new();

        public CarRepository()
        {
            db.Cars.Include(c => c.Modification).ThenInclude(m => m.Model).ThenInclude(m => m.CarBrand).ToList();
        }

        public List<CarDTO> GetCarsByModification(int modification_id)
        {
            return db.Cars.Where(c => c.ModificationId == modification_id).Select(i => new CarDTO(i)).ToList();
        }

        public CarDTO GetAvailableByModification(int mod_id)
        {
            var res = db.Cars.Where(c => c.ModificationId == mod_id && !db.Bookings.Any(b => b.CarId == c.Id)).Select(i => new CarDTO(i)).ToList();
            return res[0];
        }

        public List<CarDTO> GetAll()
        {
            return db.Cars.Select(i => new CarDTO(i)).ToList();
        }

        public bool Delete(int id)
        {
            var car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);

                return Save();
            }
            return false;
        }

        public void Add(CarDTO car)
        {
            db.Cars.Add(new Car()
            {
                Id = car.Id,
                Vin = car.Vin,
                ReleaseYear = car.ReleaseYear,
                CountryProduction = car.CountryProduction,
                ModificationId = car.ModificationId,
            });
            db.SaveChanges();
        }

        public void Update(CarDTO car)
        {
            var c = db.Cars.Find(car.Id);

            if (c != null)
            {
                c.Vin = car.Vin;
                c.ReleaseYear = car.ReleaseYear;
                c.CountryProduction = car.CountryProduction;
                c.ModificationId = car.ModificationId;

                db.SaveChanges();
            }
        }

        public bool Save()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CarDTO GetById(int id)
        {
            return new(db.Cars.Find(id));
        }
    }
}
