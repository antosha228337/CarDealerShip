using CarDealership.Utils;
using System.Windows.Media.Imaging;

namespace CarDealership.DTO
{
    public class ServiceDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public BitmapImage? Image { get; set; }

        public ServiceDTO(Service s)
        {
            Id = s.Id;
            Name = s.Name;
            Price = s.Price;
            Image = ImageConverter.ConvertByteArrayToImage(s.Image);
        }
    }
}
