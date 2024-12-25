using DAL;

namespace CarDealership.DTO
{
    class DriveTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DriveTypeDTO(DriveType dt)
        {
            Id = dt.Id;
            Name = dt.Name;
        }
    }
}
