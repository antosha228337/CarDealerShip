using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Repositories
{
    public class ModificationRepository : IModificationRepository
    {
        private CarDealershipMainContext db;

        public ModificationRepository()
        {
            db = new CarDealershipMainContext();
        }

        public void Add(ModificationDTO modification)
        {
            db.Modifications.Add(new Modification()
            {
                Name = modification.Name,
                EngineCapacity = modification.EngineCapacity,
                Horsepower = modification.Horsepower,
                Price = modification.Price,
                ModelId = modification.ModelId,
                TransmissionTypeId = modification.TransmissionTypeId,
                EngineTypeId = modification.EngineTypeId,
                DriveTypeId = modification.DriveTypeId,
                BodyTypeId = modification.BodyTypeId,
            });

            db.SaveChanges();
        }

        public List<ModificationDTO> GetAll()
        {
            return db.Modifications.Include(m => m.Model).Include(m => m.Model.CarBrand)
                .Include(m => m.TransmissionType)
                .Include(m => m.EngineType)
                .Include(m => m.DriveType)
                .Include(m => m.BodyType).Select(i => new ModificationDTO(i)).ToList();
        }

        public int GetAvailableCount(int mod_id)
        {
            int countBookedcars =  db.Bookings.Where(b => b.Car.ModificationId == mod_id).Count();
            int stockQuantity = GetStockQuantity(mod_id);
            return stockQuantity - countBookedcars;
        }

        public int GetStockQuantity(int mod_id)
        {
            return db.Cars.Where(c => c.ModificationId == mod_id).Count();
        }

        public List<ModificationDTO> GetByFilter(CarBrandDTO carBrand, EngineTypeDTO engineType, TransmissionTypeDTO trType, BodyTypeDTO bodyType)
        {
            return db.Modifications.Where(m => (carBrand == null || m.Model.CarBrandId == carBrand.Id)
                && (bodyType == null || m.BodyTypeId == bodyType.Id)
                && (trType == null || trType.Id == m.TransmissionTypeId)
                && (engineType == null || engineType.Id == m.EngineTypeId)).Select(i => new ModificationDTO(i)).ToList();
        }

        public void Update(ModificationDTO mod)
        {
            var m = db.Modifications.Find(mod.Id);
            if (m != null)
            {
                m.Name = mod.Name;
                m.EngineCapacity = mod.EngineCapacity;
                m.Horsepower = mod.Horsepower;
                m.Price = mod.Price;
                m.TransmissionTypeId = mod.TransmissionTypeId;
                m.EngineTypeId = mod.EngineTypeId;
                m.BodyTypeId = mod.BodyTypeId;
                m.DriveTypeId = mod.DriveTypeId;
                m.ModelId = mod.ModelId;
                db.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var mod = db.Modifications.Find(id);

            if (mod != null)
            {
                db.Modifications.Remove(mod);

                return Save();
            }
            return false;
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
