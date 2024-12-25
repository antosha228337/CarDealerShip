using DAL;

namespace CarDealership.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string FisrtName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? ThirdName { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public CustomerDTO()
        {
            
        }


        public CustomerDTO(Customer c)
        {
            Id = c.Id;
            FisrtName = c.FisrtName;
            LastName = c.LastName;
            ThirdName = c.ThirdName;
            PhoneNumber = c.PhoneNumber;
            Login = c.Login;
            Password = c.Password;
        }

    }
}
