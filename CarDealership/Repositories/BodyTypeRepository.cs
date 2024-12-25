using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using DAL;

namespace CarDealership.Repositories
{
    class BodyTypeRepository : IBodyTypeRepository
    {
        CarDealershipMainContext db = new();

        public List<BodyTypeDTO> GetAll() => db.BodyTypes.Select(i => new BodyTypeDTO(i)).ToList();
        
    }
}
