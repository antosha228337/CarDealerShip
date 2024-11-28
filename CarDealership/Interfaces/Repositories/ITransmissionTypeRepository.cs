
using CarDealership.DTO;

namespace CarDealership.Interfaces.Repositories
{
    interface ITransmissionTypeRepository
    {
        List<TransmissionTypeDTO> GetAll();
    }
}
