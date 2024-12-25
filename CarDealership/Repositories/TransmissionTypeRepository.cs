using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using DAL;

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
