using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using DAL;

namespace CarDealership.Repositories
{
    class DriveTypeRepository : IDriveTypeRepository
    {
        CarDealershipMainContext db = new();


        public List<DriveTypeDTO> GetAll()
        {
            return db.DriveTypes.Select(i => new DriveTypeDTO(i)).ToList();
        }
    }
}
