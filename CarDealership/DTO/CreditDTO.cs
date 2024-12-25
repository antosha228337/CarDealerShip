using DAL;

namespace CarDealership.DTO
{
    public class CreditDTO
    {
        public int Id { get; set; }

        public float InterestRate { get; set; }

        public int Period { get; set; }

        public CreditDTO(Credit c)
        {
            Id = c.Id;
            InterestRate = c.InterestRate;
            Period = c.Period;
        }
    }
}
