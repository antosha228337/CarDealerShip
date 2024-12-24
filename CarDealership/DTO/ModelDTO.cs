using CarDealership.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CarDealership.DTO
{
    internal class ModelDTO
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CarBrandId { get; set; }

        public string CarBrand {  get; set; }

        public BitmapImage? Image { get; set; }

        public ModelDTO() { }

        public ModelDTO(Model m)
        {
            Id = m.Id;
            Name = m.Name;
            CarBrandId = m.CarBrandId;
            Image = ImageConverter.ConvertByteArrayToImage(m.Image);
            CarBrand = m.CarBrand.Name;
        }
    }
}
