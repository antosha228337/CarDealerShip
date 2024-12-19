using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
