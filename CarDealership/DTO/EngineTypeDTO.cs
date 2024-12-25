using DAL;

namespace CarDealership.DTO
{
    public class EngineTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public EngineTypeDTO(EngineType t)
        {
            Id = t.Id;
            Name = t.Name;
        }
    }
}
