using CarDealership.Commands;
using CarDealership.Interfaces.Repositories;
using CarDealership.Repositories;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
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

        private Dictionary<string, int> models_count = new();

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
        public ICommand SaveReportCommand { get; set; }

        public ReportViewModel()
        {
            saleRepo = new SaleRepository();

            DateStart = DateTime.Now;
            DateEnd  = DateTime.Now;


            ShowReportCommand = new RelayCommand(OnShowReportCommandExecuted);
            SaveReportCommand = new RelayCommand(OnSaveReportCommandExecuted, CanSaveReportCommandExecute);
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

            models_count = modelsCount;

            foreach (var item in modelsCount)
            {
                s.Add(new PieSeries() { Title = item.Key, Values = new ChartValues<int> { item.Value } });
            }

            SeriesReport = s;
        }

        private bool CanSaveReportCommandExecute(object p)
        {
            return seriesReport != null && seriesReport.Count != 0;
        }

        private void OnSaveReportCommandExecuted(object p)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Сохранить файл как",
                Filter = "Все файлы (*.*)|*.*",
                FileName = "Report.csv",
                CheckPathExists = true
            };

            if (saveFileDialog.ShowDialog() == false) return;



            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "–",
                ShouldUseConstructorParameters = _ => false
            };

            using (var writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, csvConfig))
            {
                csv.WriteRecords(models_count.Select(item => new { Модель = item.Key, Коичество = item.Value }));
            }

        }


    }
}
