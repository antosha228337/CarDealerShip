using CarDealership.DTO;
using System.Net;

namespace CarDealership.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public bool CheckUserExistence(NetworkCredential credential);
        public CustomerDTO? GetCustomerByLogin(string login);
        public CustomerDTO GetCurrentCustomer();
    }
}
