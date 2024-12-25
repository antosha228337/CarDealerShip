using CarDealership.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Interfaces.Repositories
{
    interface ISaleRepository
    {
        List<SaleDTO> GetAll();
        public List<SaleDTO> GetByUserId(int id);
        void Add(SaleDTO sale);
        public List<SaleDTO> SalesByDate(DateOnly start, DateOnly end);
        public List<ServiceDTO> GetServices(int sale_id);
    }
}
