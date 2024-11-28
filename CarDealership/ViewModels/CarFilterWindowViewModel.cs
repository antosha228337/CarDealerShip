using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.ViewModels
{
    public class CarFilterWindowViewModel : ViewModelBase
    {

        ICarBrandRepository carBrandRepository;
        ITransmissionTypeRepository transmissionTypeRepository;
        IBodyTypeRepository bodyTypeRepository;
        IEngineTypeRepository engineTypeRepository;


        private List<CarBrandDTO> brands;
        private List<TransmissionTypeDTO> transmissions;
        private List<EngineTypeDTO> engines;
        private List<BodyTypeDTO> bodyTypes;

        public List<CarBrandDTO> Brands
        {
            get => brands;
            set
            {
                brands = value;
                OnPropertyChanged(nameof(Brands));
            }
        }

        public List<TransmissionTypeDTO> Transmissions
        {
            get => transmissions;
            set
            {
                transmissions = value;
                OnPropertyChanged(nameof(Transmissions));
            }
        }

        public List<EngineTypeDTO> Engines
        {
            get => engines;
            set
            {
                engines = value;
                OnPropertyChanged(nameof(Engines));
            }
        }

        public List<BodyTypeDTO> BodyTypes
        {
            get => bodyTypes;
            set
            {
                bodyTypes = value;
                OnPropertyChanged(nameof(BodyTypes)); 
            }
        }

        private CarBrandDTO selectedCarBrand;
        private TransmissionTypeDTO selectedTransmissionType;
        private EngineTypeDTO selectedEngineType;
        private BodyTypeDTO selectedBodyType;

        public CarBrandDTO SelectedCarBrand
        {
            get => selectedCarBrand;
            set
            {
                selectedCarBrand = value;
                OnPropertyChanged(nameof(SelectedCarBrand));
            }
        }

        public TransmissionTypeDTO SelectedTransmissionType
        {
            get => selectedTransmissionType;
            set
            {
                selectedTransmissionType = value;
                OnPropertyChanged(nameof(SelectedTransmissionType));
            }
        }

        public EngineTypeDTO SelectedEngineType
        {
            get => selectedEngineType;
            set
            {
                selectedEngineType = value;
                OnPropertyChanged(nameof(SelectedEngineType));
            }
        }

        public BodyTypeDTO SelectedBodyType
        {
            get => selectedBodyType;
            set
            {
                selectedBodyType = value;
                OnPropertyChanged(nameof(SelectedBodyType));
            }
        }



        public CarFilterWindowViewModel()
        {
            engineTypeRepository = new EngineTypeRepository();
            carBrandRepository = new CarBrandRepository();
            transmissionTypeRepository = new TransmissionTypeRepository();
            bodyTypeRepository = new BodyTypeRepository();
            
            Brands = carBrandRepository.GetAll();
            Transmissions = transmissionTypeRepository.GetAll();
            Engines = engineTypeRepository.GetAll();
            BodyTypes = bodyTypeRepository.GetAll();
        }


    }
}
