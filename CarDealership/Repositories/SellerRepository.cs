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
    internal class SellerRepository : ISellerRepository
    {
        private CarDealershipMainContext db;

        public SellerRepository()
        {
            db = new();
        }

        public bool CheckUserExistence(NetworkCredential credential)
        {
            return db.Sellers.Any(seller => seller.Login == credential.UserName && seller.Password == credential.Password);
        }

        public SellerDTO GetByID(int id)
        {
            return new(db.Sellers.Find(id));
        }

        public SellerDTO GetCurrentSeller()
        {
            var currentUserLogin = Thread.CurrentPrincipal?.Identity?.Name;
            SellerDTO seller;

            Seller c = new()
            {
                Id = 1,
                FirstName = "Евгений",
                LastName = "Коробенин",
                ThirdName = "Михайлович",
                PhoneNumber = "89012001221",
                Login = "seller1"
            };

            if (currentUserLogin == null) seller = new(c);

            else seller = GetSellerByLogin(currentUserLogin) ?? new(c);

            return seller;
        }

        public SellerDTO? GetSellerByLogin(string login)
        {
            return db.Sellers.Where(c => c.Login == login).Select(i => new SellerDTO(i)).FirstOrDefault();
        }
    }
}
