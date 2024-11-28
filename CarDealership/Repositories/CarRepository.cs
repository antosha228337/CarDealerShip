using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
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

        public List<CarDTO> GetCarsByModification(int modification_id)
        {
            return db.Cars.Where(c => c.ModificationId == modification_id).Select(i => new CarDTO(i)).ToList();
        }

        public CarDTO GetAvailableByModification(int mod_id)
        {
            var res = db.Cars.Where(c => c.ModificationId == mod_id && !db.Bookings.Any(b => b.CarId == c.Id)).Select(i => new CarDTO(i)).ToList();
            return res[0];
        }
    }
}
