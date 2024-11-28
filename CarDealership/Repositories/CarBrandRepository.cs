using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;

namespace CarDealership.Repositories
{
    class CarBrandRepository : ICarBrandRepository
    {
        CarDealershipMainContext db = new();

        public List<CarBrandDTO> GetAll()
        {
            return db.CarBrands.Select(i => new CarBrandDTO(i)).ToList();
        }
    }
}
