using DAL;

namespace CarDealership.DTO
{
    public class CarBrandDTO
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Country { get; set; } = null!;

        public CarBrandDTO()
        {
            
        }

        public CarBrandDTO(CarBrand car)
        {
            Id = car.Id;
            Name = car.Name;
            Country = car.Country;
        }
    }
}
