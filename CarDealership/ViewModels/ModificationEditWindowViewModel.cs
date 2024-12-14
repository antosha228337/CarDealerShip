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
    class ModificationEditWindowViewModel : ViewModelBase
    {
        IBodyTypeRepository bodyTypeRepository;
        ITransmissionTypeRepository transmissionTypeRepository;
        IEngineTypeRepository engineTypeRepository;
        IDriveTypeRepository driveTypeRepository;
        //IModificationRepository modificationRepository;
        IModelRepository modelRepository;

        #region Свойства

        private int horsePower;

        public int HorsePower
        {
            get => horsePower;
            set
            {
                horsePower = value;
                OnPropertyChanged(nameof(HorsePower));
            }
        }

        private double engineCapacity;

        public double EngineCapacity
        {
            get => engineCapacity;
            set
            {
                engineCapacity = value;
                OnPropertyChanged(nameof(EngineCapacity));
            }
        }

        private int price;

        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string modification;

        public string Modification
        {
            get => modification;
            set
            {
                modification = value;
                OnPropertyChanged(nameof(Modification));
            }
        }

        private TransmissionTypeDTO? selectedTransmission;

        public TransmissionTypeDTO? SelectedTransmission
        {
            get => selectedTransmission;
            set
            {
                selectedTransmission = value;
                OnPropertyChanged(nameof(SelectedTransmission));
            }
        }

        private EngineTypeDTO? selectedEngineType;

        public EngineTypeDTO? SelectedEngineType
        {
            get => selectedEngineType;
            set
            {
                selectedEngineType = value;
                OnPropertyChanged(nameof(SelectedEngineType));
            }
        }

        private BodyTypeDTO? selectedBodyType;

        public BodyTypeDTO? SelectedBodyType
        {
            get => selectedBodyType;
            set
            {
                selectedBodyType = value;
                OnPropertyChanged(nameof(SelectedBodyType));
            }
        }

        private DriveTypeDTO? selectedDriveType;

        public DriveTypeDTO? SelectedDriveType
        {
            get => selectedDriveType;
            set
            {
                selectedDriveType = value;
                OnPropertyChanged(nameof(SelectedDriveType));
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

        private List<TransmissionTypeDTO> transmissionTypes;

        public List<TransmissionTypeDTO> TransmissionTypes
        {
            get => transmissionTypes;
            set
            {
                transmissionTypes = value;
                OnPropertyChanged(nameof(TransmissionTypes));
            }
        }

        private List<EngineTypeDTO> engineTypes;

        public List<EngineTypeDTO> EngineTypes
        {
            get => engineTypes;
            set
            {
                engineTypes = value;
                OnPropertyChanged(nameof(EngineTypes));
            }
        }

        private List<BodyTypeDTO> bodyTypes;

        public List<BodyTypeDTO> BodyTypes
        {
            get => bodyTypes;
            set
            {
                bodyTypes = value;
                OnPropertyChanged(nameof(BodyTypes));
            }
        }

        private List<DriveTypeDTO> driveTypes;

        public List <DriveTypeDTO> DriveTypes
        {
            get => driveTypes;
            set
            {
                driveTypes = value;
                OnPropertyChanged(nameof(DriveTypes));
            }
        }
        #endregion

        public ModificationEditWindowViewModel()
        {
            bodyTypeRepository = new BodyTypeRepository();
            transmissionTypeRepository = new TransmissionTypeRepository();
            engineTypeRepository = new EngineTypeRepository();
            driveTypeRepository = new DriveTypeRepository();
            //modificationRepository = new ModificationRepository();
            modelRepository = new ModelRepository();

            TransmissionTypes = transmissionTypeRepository.GetAll();
            EngineTypes = engineTypeRepository.GetAll();
            BodyTypes = bodyTypeRepository.GetAll();
            DriveTypes = driveTypeRepository.GetAll();
            Models = modelRepository.GetAll();
        }
    }
}
