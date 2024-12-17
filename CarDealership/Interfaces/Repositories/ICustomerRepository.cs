using CarDealership.DTO;
using System.Net;

namespace CarDealership.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public bool CheckUserExistence(NetworkCredential credential);
        public CustomerDTO? GetCustomerByLogin(string login);
        public CustomerDTO GetCurrentCustomer();
        public CustomerDTO GetByID(int id);
        public void Add(CustomerDTO c);
        public bool CheckAvailableLogin(string login);
    }
}
