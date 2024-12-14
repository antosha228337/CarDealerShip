using CarDealership.DTO;

namespace CarDealership.Interfaces.Repositories
{
    interface IDriveTypeRepository
    {
        List<DriveTypeDTO> GetAll();
    }
}
