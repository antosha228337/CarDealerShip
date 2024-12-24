using CarDealership.Commands;
using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using CarDealership.Views.Windows;
using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarDealership.ViewModels
{
    class DataStorageViewModel : ViewModelBase
    {
        private ICarBrandRepository carBrandRepository;
        private IModificationRepository modificationRepository;
        private IModelRepository modelRepository;
        private ICarRepository carRepository;

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

        private List<ModificationDTO> modifications;

        public List<ModificationDTO> Modifications 
        { 
            get => modifications;
            set
            {
                modifications = value;
                OnPropertyChanged(nameof(Modifications));
            }
        }

        private List<ModelDTO> models;

        public List<ModelDTO> Models
        {
            get => models;
            set
            {
                models = value;
                OnPropertyChanged(nameof(Models));
            }
        }

        private List<CarDTO> cars;

        public List<CarDTO> Cars
        {
            get => cars;
            set
            {
                cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }

        private CarDTO selectedCar;

        public CarDTO SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
            }
        }

        private CarBrandDTO? selectedCarBrand;

        public CarBrandDTO? SelectedCarBrand
        {
            get => selectedCarBrand;
            set
            {
                selectedCarBrand = value;
                OnPropertyChanged(nameof(selectedCarBrand));
            }
        }

        private ModelDTO? selectedModel;

        public ModelDTO? SelectedModel
        {
            get => selectedModel;
            set
            {
                selectedModel = value;
                OnPropertyChanged(nameof(SelectedModel));
            }
        }

        private ModificationDTO? selectedModification;

        public ModificationDTO? SelectedModification
        {
            get => selectedModification;
            set
            {
                selectedModification = value;
                OnPropertyChanged(nameof(SelectedModification));
            }
        }

        public ICommand AddCarBrandCommand { get; set; }
        public ICommand RemoveCarBrandCommand { get; set; }
        public ICommand EditCarBrandCommand { get; set; }

        public ICommand AddModificationCommand { get; set; }
        public ICommand RemoveModificationCommand { get; set; }
        public ICommand EditModificationCommand { get; set; }

        public ICommand AddModelCommand { get; set; }
        public ICommand RemoveModelCommand { get; set; }
        public ICommand EditModelCommand { get; set; }

        public ICommand AddCarCommand { get; set; }
        public ICommand RemoveCarCommand { get; set; }
        public ICommand EditCarCommand { get; set; }

        public DataStorageViewModel()
        {

            carBrandRepository = new CarBrandRepository();
            modificationRepository = new ModificationRepository();
            modelRepository = new ModelRepository();
            carRepository = new CarRepository();

            Brands = carBrandRepository.GetAll();
            Modifications = modificationRepository.GetAll();
            Models = modelRepository.GetAll();
            Cars = carRepository.GetAll();

            AddCarBrandCommand = new RelayCommand(OnAddCarBrandCommandExecuted);
            RemoveCarBrandCommand = new RelayCommand(OnRemoveCarBrandCommandExecuted, CanRemoveCarBrandCommandExecute);
            EditCarBrandCommand = new RelayCommand(OnEditCarBrandCommandExecuted, CanEditCarBrandCommandExecute);

            EditModelCommand = new RelayCommand(OnEditModelCommandExecuted, CanEditModelCommandExecute);
            AddModelCommand = new RelayCommand(OnAddModelCommandExecuted);
            RemoveModelCommand = new RelayCommand(OnRemoveModelCommandExecuted, CanRemoveModelCommandExecute);

            AddModificationCommand = new RelayCommand(OnAddModificationCommandExecuted);
            EditModificationCommand = new RelayCommand(OnEditModificationCommandExecuted, CanEditModificationCommandExecute);
            RemoveModificationCommand = new RelayCommand(OnRemoveModificationCommandExecuted, CanRemoveModificationCommandExecute);

            AddCarCommand = new RelayCommand(OnAddCarCommandExecuted);
            EditCarCommand = new RelayCommand(OnEditCarCommandExecuted, CanEditCarCommandExecute);
            RemoveCarCommand = new RelayCommand(OnRemoveCarCommandExecuted, CanRemoveCarCommandExecute);
        
        }

        private void OnAddCarBrandCommandExecuted(object p)
        {
            CarBrandEditView w = new();
            CarBrandViewModel vm = new();
            w.DataContext = vm;
            
            if (w.ShowDialog() == false) return;

            CarBrandDTO brand = new();
            brand.Name = vm.Name;
            brand.Country = vm.Country;

            carBrandRepository.AddBrand(brand);
            Brands = carBrandRepository.GetAll();
        }

        private bool CanRemoveCarBrandCommandExecute(object p) => selectedCarBrand != null;

        private void OnRemoveCarBrandCommandExecuted(object p)
        {
            if (selectedCarBrand != null)
            {
                if (carBrandRepository.DeleteBrand(selectedCarBrand.Id))
                {
                    Brands = carBrandRepository.GetAll();
                }
                else
                {
                    MessageBox.Show("Невозможно удалить сущность, так как она используется в таблицах", "Удаление не выполнено");
                }
            }
        }

        private bool CanEditCarBrandCommandExecute(object p) => selectedCarBrand != null;

        private void OnEditCarBrandCommandExecuted(object p)
        {
            if ( selectedCarBrand != null)
            {
                CarBrandEditView w = new();

                CarBrandViewModel vm = new();
                vm.Name = selectedCarBrand.Name;
                vm.Country = selectedCarBrand.Country;

                w.DataContext= vm;

                if (w.ShowDialog() == false) return;

                CarBrandDTO brand = new();
                brand.Id = selectedCarBrand.Id;
                brand.Name = vm.Name;
                brand.Country = vm.Country;

                carBrandRepository.UpdateBrand(brand);
                Brands = carBrandRepository.GetAll();
            }
            
        }


        private bool CanEditModelCommandExecute(object p) => selectedModel != null;

        private void OnEditModelCommandExecuted(object p)
        {
            if (selectedModel != null)
            {

                ModelEditWindowViewModel vm = new();

                vm.CurrentImage = selectedModel.Image;
                vm.SelectedCarBrand = vm.Brands.FirstOrDefault(i => i.Id == selectedModel.CarBrandId);
                vm.ModelName = selectedModel.Name;

                ModelEditWindow w = new();
                w.DataContext = vm;

                if (w.ShowDialog() == false) return;

                ModelDTO model = new ModelDTO();

                model.Id = selectedModel.Id;    
                model.Name = vm.ModelName;
                model.Image = vm.CurrentImage;
                model.CarBrandId = vm.SelectedCarBrand.Id;

                modelRepository.Update(model);
                Models = modelRepository.GetAll();
            }
        }

        private void OnAddModelCommandExecuted(object p)
        {
            ModelEditWindowViewModel vm = new();

            ModelEditWindow w = new();
            w.DataContext = vm;

            if (w.ShowDialog() == false) return;

            ModelDTO model = new();
            model.Image = vm.CurrentImage;
            model.Name = vm.ModelName;
            model.CarBrandId = vm.SelectedCarBrand.Id;

            modelRepository.AddModel(model);
            Models = modelRepository.GetAll();
        }

        private bool CanRemoveModelCommandExecute(object p) => selectedModel != null;

        private void OnRemoveModelCommandExecuted(object p)
        {
            if (selectedModel != null)
            {

                if (modelRepository.Delete(selectedModel.Id))
                {
                    Models = modelRepository.GetAll();
                }
                else
                {
                    MessageBox.Show("Невозможно удалить сущность, так как она используется в таблицах", "Удаление не выполнено");
                }
            }

            
        }


        private void OnAddModificationCommandExecuted(object p)
        {
            ModificationEditWindow w = new();

            ModificationEditWindowViewModel vm = new();

            w.DataContext = vm;

            if (w.ShowDialog() == false) return;

            ModificationDTO mod = new();

            mod.Name = vm.Modification;
            mod.Horsepower = vm.HorsePower;
            mod.EngineCapacity = (float) vm.EngineCapacity;
            mod.Price = vm.Price;
            mod.ModelId = vm.SelectedModel.Id;
            mod.TransmissionTypeId = vm.SelectedTransmission.Id;
            mod.EngineTypeId = vm.SelectedEngineType.Id;
            mod.BodyTypeId = vm.SelectedBodyType.Id;
            mod.DriveTypeId = vm.SelectedDriveType.Id;

            modificationRepository.Add(mod);
            Modifications = modificationRepository.GetAll();

        }

        private bool CanEditModificationCommandExecute(object p) => selectedModification != null;

        private void OnEditModificationCommandExecuted(object p)
        {
            if (selectedModification != null)
            {
                ModificationEditWindow w = new();
                ModificationEditWindowViewModel vm = new();


                vm.HorsePower = selectedModification.Horsepower;
                vm.EngineCapacity = selectedModification.EngineCapacity;
                vm.Price = selectedModification.Price;
                vm.Modification = selectedModification.Name;
                vm.SelectedTransmission = vm.TransmissionTypes.FirstOrDefault(i => i.Id == selectedModification.TransmissionTypeId);
                vm.SelectedEngineType = vm.EngineTypes.FirstOrDefault(i => i.Id == selectedModification.EngineTypeId);
                vm.SelectedDriveType = vm.DriveTypes.FirstOrDefault(d => d.Id == selectedModification.DriveTypeId);
                vm.SelectedBodyType = vm.BodyTypes.FirstOrDefault(i => i.Id == selectedModification.BodyTypeId);
                vm.SelectedModel = vm.Models.FirstOrDefault(i => i.Id == selectedModification.ModelId);

                w.DataContext = vm;

                if (w.ShowDialog() == false) return;

                selectedModification.Name = vm.Modification;
                selectedModification.Horsepower = vm.HorsePower;
                selectedModification.EngineCapacity = (float) vm.EngineCapacity;
                selectedModification.Price = vm.Price;
                selectedModification.ModelId = vm.SelectedModel.Id;
                selectedModification.TransmissionTypeId = vm.SelectedTransmission.Id;
                selectedModification.BodyTypeId = vm.SelectedBodyType.Id;
                selectedModification.DriveTypeId = vm.SelectedDriveType.Id;
                selectedModification.EngineTypeId = vm.SelectedEngineType.Id;

                modificationRepository.Update(selectedModification);

                Modifications = modificationRepository.GetAll();    

            }
        }

        private bool CanRemoveModificationCommandExecute(object p) => selectedModification != null;

        private void OnRemoveModificationCommandExecuted(object p)
        {
            if (selectedModification != null)
            {                

                if (modificationRepository.Delete(selectedModification.Id))
                {
                    Modifications = modificationRepository.GetAll();
                }
                else
                {
                    MessageBox.Show("Невозможно удалить сущность, так как она используется в таблицах", "Удаление не выполнено");
                }
            }
        }

        
        private void OnAddCarCommandExecuted(object p)
        {
            CarEditWindow w = new();

            CarEditWindowViewModel vm = new();

            w.DataContext = vm;

            if (w.ShowDialog() == false) return;

            CarDTO car = new();

            car.Vin = vm.Vin;
            car.ReleaseYear = vm.ReleaseYear;
            car.CountryProduction = vm.CountryProduction;
            car.ModificationId = vm.SelectedModification.Id;
            
            carRepository.Add(car);
            Cars = carRepository.GetAll();

        }

        private bool CanEditCarCommandExecute(object p) => selectedCar != null;

        private void OnEditCarCommandExecuted(object p)
        {
            if (selectedCar != null)
            {
                CarEditWindow w = new();

                CarEditWindowViewModel vm = new();

                vm.Vin = selectedCar.Vin;
                vm.ReleaseYear = selectedCar.ReleaseYear;
                vm.CountryProduction = selectedCar.CountryProduction;
                vm.SelectedModification = vm.Modifications.FirstOrDefault(i => i.Id == selectedCar.ModificationId);

                w.DataContext = vm;

                if (w.ShowDialog() == false) return;

                selectedCar.CountryProduction = vm.CountryProduction;
                selectedCar.Vin = vm.Vin;
                selectedCar.ReleaseYear = vm.ReleaseYear;
                selectedCar.ModificationId = vm.SelectedModification.Id;

                carRepository.Update(selectedCar);
                Cars = carRepository.GetAll();
            }
        }

        private bool CanRemoveCarCommandExecute(object p) => selectedCar != null;

        private void OnRemoveCarCommandExecuted(object p)
        {
            if (selectedCar != null)
            {

                if (carRepository.Delete(selectedCar.Id))
                {
                    Cars = carRepository.GetAll();
                }
                else
                {
                    MessageBox.Show("Невозможно удалить сущность, так как она используется в таблицах", "Удаление не выполнено");
                }

            }
        }

    }
}
