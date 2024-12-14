using CarDealership.DTO;
using System.Net;

namespace CarDealership.Interfaces.Repositories
{
    internal interface ISellerRepository
    {
        public bool CheckUserExistence(NetworkCredential credential);
        public SellerDTO? GetSellerByLogin(string login);
        public SellerDTO GetCurrentSeller();
        public SellerDTO GetByID(int id);
    }
}
