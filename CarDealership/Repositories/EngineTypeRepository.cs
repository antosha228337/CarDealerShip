using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using DAL;

namespace CarDealership.Repositories
{
    class EngineTypeRepository : IEngineTypeRepository
    {
        CarDealershipMainContext db = new();

        public List<EngineTypeDTO> GetAll()
        {
            return db.EngineTypes.Select(i => new EngineTypeDTO(i)).ToList();
        }
    }
}
