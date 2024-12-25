using System;
using System.Collections.Generic;

namespace DAL;

public partial class Sale
{
    public int Id { get; set; }

    public DateOnly SaleDate { get; set; }

    public int TotalPrice { get; set; }

    public int CarPrice { get; set; }

    public int CustomerId { get; set; }

    public int SellerId { get; set; }

    public int CarId { get; set; }

    public int? CreditId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Credit? Credit { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Seller Seller { get; set; } = null!;

    public virtual ICollection<ServiceSale> ServiceSales { get; set; } = new List<ServiceSale>();
}
