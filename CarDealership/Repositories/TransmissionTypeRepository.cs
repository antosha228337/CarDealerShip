using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;

namespace CarDealership.Repositories
{
    class TransmissionTypeRepository : ITransmissionTypeRepository
    {
        CarDealershipMainContext db = new();

        public List<TransmissionTypeDTO> GetAll()
        {
            return db.TransmissionTypes.Select(i => new TransmissionTypeDTO(i)).ToList();   
        }
    }
}
