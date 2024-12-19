using CarDealership.Commands;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CarDealership.ViewModels
{
    internal class ReportViewModel : ViewModelBase
    {

        public ISaleRepository saleRepo;
        
        private SeriesCollection seriesReport;

        public SeriesCollection SeriesReport
        {
            get => seriesReport;
            set
            {
                seriesReport = value;
                OnPropertyChanged(nameof(SeriesReport));
            }
        }

        private DateTime startDate;

        public DateTime DateStart
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(DateStart));
            }
        }

        private DateTime endDate;

        public DateTime DateEnd
        {
            get => endDate;
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(DateEnd));
            }
        }

        public ICommand ShowReportCommand { get; set; }

        public ReportViewModel()
        {
            saleRepo = new SaleRepository();

            DateStart = DateTime.Now;
            DateEnd  = DateTime.Now;


            ShowReportCommand = new RelayCommand(OnShowReportCommandExecuted);
        }

        private void OnShowReportCommandExecuted(object p)
        {
            var sales = saleRepo.SalesByDate(DateOnly.FromDateTime(startDate), DateOnly.FromDateTime(endDate));
            SeriesCollection s = new();

            Dictionary<string, int> modelsCount = new();

            foreach (var sale in sales)
            {
                if (modelsCount.ContainsKey(sale.CarModel)) modelsCount[sale.CarModel]++;
                else modelsCount[sale.CarModel] = 1;
            }


            foreach (var item in modelsCount)
            {
                s.Add(new PieSeries() { Title = item.Key, Values = new ChartValues<int> { item.Value } });
            }

            SeriesReport = s;
        }
    }
}
