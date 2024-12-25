using DAL;

namespace CarDealership.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }

        public DateOnly SaleDate { get; set; }

        public int TotalPrice { get; set; }

        public int CarPrice { get; set; }

        public int CustomerId { get; set; }

        public int SellerId { get; set; }

        public int CarId { get; set; }

        public int? CreditId { get; set; }

        public List<ServiceDTO> Services = new();

        public int PaidSum { get; set; }

        public string CarBrand {  get; set; }

        public string CarModel{ get; set; }

        public string CarModification {  get; set; }

        public string CarVin {  get; set; }

        public SaleDTO()
        {
            
        }

        public SaleDTO(Sale s)
        {
            Id = s.Id;
            SaleDate = s.SaleDate;
            TotalPrice = s.TotalPrice;
            CarPrice = s.CarPrice;
            CustomerId = s.CustomerId;
            SellerId = s.SellerId;
            CarId = s.CarId;
            CreditId = s.CreditId;

            CarBrand = s.Car.Modification.Model.CarBrand.Name;
            CarModel = s.Car.Modification.Model.Name;
            CarModification = s.Car.Modification.Name;
            CarVin = s.Car.Vin;

            PaidSum = s.Payments.Sum(pay => pay.Amount);
        }
    }
}
