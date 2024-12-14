using CarDealership.DTO;

namespace CarDealership.Interfaces.Repositories
{
    internal interface ICreditRepository
    {
        List<CreditDTO> GetAll();
    }
}
