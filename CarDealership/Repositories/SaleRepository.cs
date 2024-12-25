using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using DAL;

namespace CarDealership.Repositories
{
    class SaleRepository : ISaleRepository
    {

        CarDealershipMainContext db;

        public SaleRepository()
        {
            db = new();
            db.Sales.Include(s => s.Payments).Include(s => s.Car).ThenInclude(c => c.Modification).ThenInclude(m => m.Model).ThenInclude(m => m.CarBrand).ToList();
        }

        public void Add(SaleDTO sale)
        {
            var s = new Sale()
            {
                SaleDate = sale.SaleDate,
                TotalPrice = sale.TotalPrice,
                CarPrice = sale.CarPrice,
                CustomerId = sale.CustomerId,
                SellerId = sale.SellerId,
                CarId = sale.CarId,
                CreditId = sale.CreditId,
            };


            db.Add(s);

            db.SaveChanges();

            for (int i = 0; i != sale.Services.Count; i++)
            {
                db.ServiceSales.Add(new ServiceSale() { SaleId = s.Id, ServiceId = sale.Services[i].Id, ServicePrice = sale.Services[i].Price });
            }

            db.SaveChanges();
        }

        public List<SaleDTO> GetAll()
        {
            return db.Sales.Select(i => new SaleDTO(i)).ToList();
        }

        public List<ServiceDTO> GetServices(int sale_id)
        {
            var res = db.ServiceSales
                        .Where(ss => ss.SaleId == sale_id)
                        .Join(db.Services,
                              ss => ss.ServiceId,
                              s => s.Id,
                              (ss, s) => new ServiceDTO(s))
                        .ToList();

            return res;
        }

        public List<SaleDTO> GetByUserId(int id)
        {
            return db.Sales.Where(s => s.CustomerId == id).Select(i => new SaleDTO(i)).ToList();
        }

        public List<SaleDTO> SalesByDate(DateOnly start, DateOnly end)
        {
            return db.Sales.Where(s => s.SaleDate >= start && s.SaleDate <= end).Select(i => new SaleDTO(i)).ToList();
        }
    }
}
