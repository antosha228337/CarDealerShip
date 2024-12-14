using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CarDealership.Utils;

namespace CarDealership.DTO
{
    public class ModificationDTO
    {

        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public int Horsepower { get; set; }

        public float EngineCapacity { get; set; }

        public int Price { get; set; }

        public int ModelId { get; set; }

        public int TransmissionTypeId { get; set; }

        public int EngineTypeId { get; set; }

        public int DriveTypeId { get; set; }

        public int BodyTypeId { get; set; }


        public string Model { get; set; }

        public string CarBrand {  get; set; }

        public string Transmission { get; set; }

        public string EngineType { get; set; }

        public string BodyType { get; set; }

        public string DriveType { get; set; }
        
        public BitmapImage? Image { get; set; }

        public ModificationDTO()
        {
            
        }

        public ModificationDTO(Modification modification)
        {
            Id = modification.Id;
            Name = modification.Name;
            Horsepower = modification.Horsepower;
            EngineCapacity = modification.EngineCapacity;
            Price = modification.Price;
            ModelId = modification.ModelId;
            TransmissionTypeId = modification.TransmissionTypeId;
            EngineTypeId = modification.EngineTypeId;
            BodyTypeId = modification.BodyTypeId;
            DriveTypeId = modification.DriveTypeId;


            Model = modification.Model.Name;
            CarBrand = modification.Model.CarBrand.Name;
            Transmission = modification.TransmissionType.Name;
            BodyType = modification.BodyType.Name;
            EngineType = modification.EngineType.Name;
            DriveType = modification.DriveType.Name;
            Image = ImageConverter.ConvertByteArrayToImage(modification.Model.Image);
        }
    }
}
