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
            throw new NotImplementedException();
        }

        public List<ModificationDTO> GetAll()
        {
            return db.Modifications.Include(m => m.Model).Include(m => m.Model.CarBrand)
                .Include(m => m.TransmissionType)
                .Include(m => m.EngineType)
                .Include(m => m.DriveType)
                .Include(m => m.BodyType).Select(i => new ModificationDTO(i)).ToList();
        }
    }
}
