namespace CarDealership.DTO
{
    public class ModificationDTO
    {

        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public int Horsepower { get; set; }

        public float EngineCapacity { get; set; }

        public int Price { get; set; }

        public string Model { get; set; }

        public string CarBrand {  get; set; }

        public string Transmission { get; set; }

        public string EngineType { get; set; }

        public string BodyType { get; set; }

        public string DriveType { get; set; }

        //public int ModelId { get; set; }

        //public int TransmissionTypeId { get; set; }

        //public int EngineTypeId { get; set; }

        //public int DriveTypeId { get; set; }

        //public int BodyTypeId { get; set; }

        //public virtual BodyType BodyType { get; set; } = null!;

        //public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

        //public virtual DriveType DriveType { get; set; } = null!;

        //public virtual EngineType EngineType { get; set; } = null!;

        //public virtual Model Model { get; set; } = null!;

        //public virtual TransmissionType TransmissionType { get; set; } = null!;



        public ModificationDTO(Modification modification)
        {
            Id = modification.Id;
            Name = modification.Name;
            Horsepower = modification.Horsepower;
            EngineCapacity = modification.EngineCapacity;
            Price = modification.Price;
            Model = modification.Model.Name;
            CarBrand = modification.Model.CarBrand.Name;
            Transmission = modification.TransmissionType.Name;
            BodyType = modification.BodyType.Name;
            EngineType = modification.EngineType.Name;
            DriveType = modification.DriveType.Name;
        }
    }
}
