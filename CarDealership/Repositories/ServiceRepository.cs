using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using DAL;

namespace CarDealership.Repositories
{
    internal class ServiceRepository : IServiceRepository
    {
        private CarDealershipMainContext db;

        public ServiceRepository()
        {
            db = new();
        }

        public List<ServiceDTO> GetAll()
        {
            return db.Services.Select(i => new ServiceDTO(i)).ToList();
        }
    }
}
