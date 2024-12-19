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
        IPaymentRepository paymentRepo;

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

        private SaleDTO? selectedSale;

        public SaleDTO? SelectedSale
        {
            get => selectedSale;
            set
            {
                selectedSale = value;
                Payments = paymentRepo.GetBySaleId(selectedSale.Id);
                OnPropertyChanged(nameof(SelectedSale));
            }
        }

        private List<PaymentDTO> payments;

        public List<PaymentDTO> Payments
        {
            get => payments;
            set
            {
                payments = value;
                OnPropertyChanged(nameof(Payments));
            }
        }
        #endregion

        public SalesViewModel()
        {
            saleRepository = new SaleRepository();
            paymentRepo = new PaymentRepository();
            Sales = saleRepository.GetAll();
        }

    }
}
