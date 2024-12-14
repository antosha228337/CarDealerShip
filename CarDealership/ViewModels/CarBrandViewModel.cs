using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.ViewModels
{
    class CarBrandViewModel : ViewModelBase
    {
        private string name;
        private string country;

        public string Name
        {
            get => name; 
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            } 
        }

        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
    }
}
