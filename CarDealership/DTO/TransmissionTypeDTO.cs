using DAL;

namespace CarDealership.DTO
{
    public class TransmissionTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public TransmissionTypeDTO(TransmissionType t)
        {
            Id = t.Id;
            Name = t.Name;
        }
    }
}
