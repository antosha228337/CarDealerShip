using CarDealership.DTO;

namespace CarDealership.Interfaces.Repositories
{
    public interface IModificationRepository
    {
        void Add(ModificationDTO modification);
        List<ModificationDTO> GetAll();
        int GetStockQuantity(int mod_id);
        int GetAvailableCount(int mod_id);
        List<ModificationDTO> GetByFilter(CarBrandDTO carBrand, EngineTypeDTO engineType, TransmissionTypeDTO trType, BodyTypeDTO bodyType);
    }
}
