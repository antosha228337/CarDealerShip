using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using DAL;

namespace CarDealership.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        CarDealershipMainContext db;

        public PaymentRepository()
        {
            db = new();
        }

        public List<PaymentDTO> GetBySaleId(int id)
        {
            return db.Payments.Where(p => p.SaleId == id).Select(i => new PaymentDTO(i)).ToList();
        }
    }
}
