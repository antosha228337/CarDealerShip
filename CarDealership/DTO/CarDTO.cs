using CarDealership.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CarDealership.DTO
{
    internal class CarDTO
    {

        public int Id { get; set; }

        public string Vin { get; set; } = null!;

        public int ReleaseYear { get; set; }

        public string Brand { get; set; }

        public string ModelName { get; set; }

        public string ModificationName { get; set; }

        public string CountryProduction { get; set; } = null!;

        public int CarPrice { get; set; }

        public int ModificationId { get; set; }

        public BitmapImage? Image { get; set; }

        public CarDTO()
        {
            
        }

        public CarDTO(Car car)
        {
            Id = car.Id;
            Vin = car.Vin;
            ReleaseYear = car.ReleaseYear;
            CountryProduction = car.CountryProduction;
            ModificationId = car.ModificationId;
            Brand = car.Modification.Model.CarBrand.Name;
            ModelName = car.Modification.Model.Name;
            ModificationName = car.Modification.Name;
            CarPrice = car.Modification.Price;
            Image = ImageConverter.ConvertByteArrayToImage(car.Modification.Model.Image);
        }
    }
}
