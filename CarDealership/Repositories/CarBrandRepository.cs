using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using DAL;

namespace CarDealership.Repositories
{
    class CarBrandRepository : ICarBrandRepository
    {
        CarDealershipMainContext db = new();

        public void AddBrand(CarBrandDTO brand)
        {
            db.CarBrands.Add(new CarBrand()
            {
                Name = brand.Name,
                Country = brand.Country,
            });
            db.SaveChanges();
        }

        public bool DeleteBrand(int id)
        {
            var brand = db.CarBrands.Find(id);
            if (brand != null)
            {
                var t = db.CarBrands.Remove(brand);

                return Save();

                //db.SaveChanges();
            }
            return false;
        }

        public List<CarBrandDTO> GetAll()
        {
            return db.CarBrands.Select(i => new CarBrandDTO(i)).ToList();
        }

        public void UpdateBrand(CarBrandDTO brand)
        {
            var model = db.CarBrands.Find(brand.Id);
            if (model != null)
            {
                model.Name = brand.Name;    
                model.Country = brand.Country;
                db.SaveChanges();
            }
        }

        public CarBrandDTO GetById(int id)
        {
            throw new NotImplementedException();
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
    }
}
