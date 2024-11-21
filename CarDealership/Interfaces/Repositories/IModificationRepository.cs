using CarDealership.DTO;

namespace CarDealership.Interfaces.Repositories
{
    public interface IModificationRepository
    {
        void Add(ModificationDTO modification);
        List<ModificationDTO> GetAll();
    }
}
