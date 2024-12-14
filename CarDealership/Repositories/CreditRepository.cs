using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;

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
