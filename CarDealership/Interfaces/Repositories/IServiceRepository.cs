using CarDealership.DTO;

namespace CarDealership.Interfaces.Repositories
{
    internal interface IServiceRepository
    {
        List<ServiceDTO> GetAll();
    }
}
