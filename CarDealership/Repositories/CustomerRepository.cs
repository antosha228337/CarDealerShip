using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        CarDealershipMainContext db = new();

        public bool CheckUserExistence(NetworkCredential credential) =>
            db.Customers.Any(customer => customer.Login == credential.UserName && customer.Password == credential.Password);

        public CustomerDTO GetByID(int id)
        {
            return new(db.Customers.Find(id));
        }

        public bool CheckAvailableLogin(string login)
        {
            bool r1 = db.Customers.Any(c => c.Login == login);
            bool r2 = db.Sellers.Any(s => s.Login == login);
            return !(r1 || r2);
        }

        public void Add(CustomerDTO c)
        {
            db.Customers.Add(new Customer()
            {
                FisrtName = c.FisrtName,
                LastName = c.LastName,
                ThirdName = c.ThirdName,
                PhoneNumber = c.PhoneNumber,
                Login = c.Login,
                Password = c.Password,
            });

            db.SaveChanges();
        }

        public CustomerDTO GetCurrentCustomer()
        {
            var currentUserLogin = Thread.CurrentPrincipal?.Identity?.Name;
            CustomerDTO customer;

            Customer c = new()
            {
                Id = 1,
                FisrtName = "Иван",
                LastName = "Иванов",
                ThirdName = "Иванович",
                PhoneNumber = "89001112233",
                Login = "user1"
            };

            if (currentUserLogin == null) customer = new(c);

            else customer = GetCustomerByLogin(currentUserLogin) ?? new(c);
            
            return customer;
        }

        public CustomerDTO? GetCustomerByLogin(string login)
        {
            return db.Customers.Where(c => c.Login == login).Select(i => new CustomerDTO(i)).FirstOrDefault();
        }
    }
}
