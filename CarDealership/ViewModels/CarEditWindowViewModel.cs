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
    internal class CarEditWindowViewModel :ViewModelBase
    {
        IModificationRepository modificationRepository;
        
        private ModificationDTO selectedModification;

        public ModificationDTO SelectedModification
        {
            get => selectedModification;
            set
            {
                selectedModification = value;
                OnPropertyChanged(nameof(SelectedModification));
            }
        }


        private List<ModificationDTO>  modifications;

        public List<ModificationDTO> Modifications
        {
            get => modifications;
            set
            {
                modifications = value;
                OnPropertyChanged(nameof(Modifications));
            }
        }

        private string vin;

        public string Vin
        {
            get => vin;
            set
            {
                vin = value;
                OnPropertyChanged(nameof(Vin));
            }
        }

        private string countryProduction;

        public string CountryProduction
        {
            get => countryProduction;
            set
            {
                countryProduction = value;
                OnPropertyChanged(nameof(CountryProduction));
            }
        }

        private int releaseYear;

        public int ReleaseYear
        {
            get => releaseYear;
            set
            {
                releaseYear = value;
                OnPropertyChanged(nameof(ReleaseYear));
            }
        }

        public CarEditWindowViewModel()
        {
            modificationRepository = new ModificationRepository();
            Modifications = modificationRepository.GetAll();
        }
    }
}
