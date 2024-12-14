using CarDealership.Commands;
using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CarDealership.ViewModels
{
    public class ModelEditWindowViewModel : ViewModelBase
    {

        private ICarBrandRepository carBrandRepository;

        private BitmapImage? currentImage;

        public BitmapImage? CurrentImage
        {
            get => currentImage;
            set
            {
                currentImage = value;
                OnPropertyChanged(nameof(CurrentImage));
            }
        }


        private CarBrandDTO selectedCarBrand;

        public CarBrandDTO SelectedCarBrand
        {
            get => selectedCarBrand;
            set
            {
                selectedCarBrand = value;
                OnPropertyChanged(nameof(SelectedCarBrand));
            }
        }

        private List<CarBrandDTO> brands;

        public List<CarBrandDTO> Brands
        {
            get => brands;
            set
            {
                brands = value;
                OnPropertyChanged(nameof(Brands));
            }
        }

        private string modelName;

        public string ModelName
        {
            get => modelName;
            set
            {
                modelName = value;
                OnPropertyChanged(nameof(ModelName));
            }
        }

        public ICommand ChangeImageCommand { get; set; }

        public ModelEditWindowViewModel()
        {
            carBrandRepository = new CarBrandRepository();

            Brands = carBrandRepository.GetAll();

            ChangeImageCommand = new RelayCommand(OnChangeImageCommandExecuted);
        }

        private void OnChangeImageCommandExecuted(object p)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image files (*.jpg)|*.jpg";

            if (dialog.ShowDialog() == false) return;

            var path = dialog.FileName;

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource = new Uri(path);
            bitmapImage.EndInit();

            CurrentImage = bitmapImage;         
        }
    }
}
