using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateOnly Date { get; set; }

        public int SaleId { get; set; }

        public PaymentDTO(Payment p)
        {
            Id = p.Id;
            Amount = p.Amount;
            Date = p.Date;
            SaleId = p.SaleId;
        }
    }
}
