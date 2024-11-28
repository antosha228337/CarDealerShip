using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
        
        public BitmapImage? Image { get; set; }

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
            Image = ConvertByteArrayToImage(modification.Model.Image);
        }


        public static BitmapImage ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
                return null;

            var image = new BitmapImage();
            using (var memStream = new MemoryStream(byteArray))
            {
                memStream.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = memStream;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
