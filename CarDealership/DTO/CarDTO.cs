using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DTO
{
    internal class CarDTO
    {

        public int Id { get; set; }

        public string Vin { get; set; } = null!;

        public int ReleaseYear { get; set; }

        public string CountryProduction { get; set; } = null!;

        public int ModificationId { get; set; }

        public CarDTO(Car car)
        {
            Id = car.Id;
            Vin = car.Vin;
            ReleaseYear = car.ReleaseYear;
            CountryProduction = car.CountryProduction;
            ModificationId = car.ModificationId;
        }
    }
}
