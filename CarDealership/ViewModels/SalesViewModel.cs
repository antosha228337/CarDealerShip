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
    class SalesViewModel : ViewModelBase
    {

        ISaleRepository saleRepository;

        #region Свойства
        private List<SaleDTO> sales;

        public List<SaleDTO> Sales
        {
            get => sales;
            set
            {
                sales = value;
                OnPropertyChanged(nameof(Sales));
            }
        }
        #endregion

        public SalesViewModel()
        {
            saleRepository = new SaleRepository();
            Sales = saleRepository.GetAll();
        }

    }
}
