using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DTO
{
    public class SellerDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? ThirdName { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int WorkExperience { get; set; }

        public SellerDTO(Seller s)
        {
            Id = s.Id;
            FirstName = s.FirstName;
            LastName = s.LastName;
            ThirdName = s.ThirdName;
            PhoneNumber = s.PhoneNumber;
            Login = s.Login;
            Password = s.Password;
            WorkExperience = s.WorkExperience;
        }
    }
}
