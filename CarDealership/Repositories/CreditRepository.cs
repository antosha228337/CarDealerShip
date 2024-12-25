using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using DAL;

namespace CarDealership.Repositories
{
    internal class CreditRepository : ICreditRepository
    {
        CarDealershipMainContext db;

        public CreditRepository()
        {
            db = new();
        }

        public List<CreditDTO> GetAll() => db.Credits.Select(i => new CreditDTO(i)).ToList();
        
    }
}
