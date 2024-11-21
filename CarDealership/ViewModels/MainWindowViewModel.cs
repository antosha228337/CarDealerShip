using CarDealership.DTO;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private List<Model> allmodels;
        private CarDealershipMainContext context;

        private IModificationRepository modificationRepository;

        private List<ModificationDTO> allModifications;

        public List<ModificationDTO> AllModifications
        {
            get => allModifications;
            set
            {
                allModifications = value;
                OnPropertyChanged(nameof(AllModifications));
            }
        }

        public List<Model> Allmodels
        {
            get => allmodels; 
            set
            {
                allmodels = value;
                OnPropertyChanged(nameof(Allmodels));
            }
        }

        public MainWindowViewModel()
        {


            modificationRepository = new ModificationRepository();
            AllModifications = modificationRepository.GetAll();

        }
    }
}
