using System;
using System.Collections.Generic;

namespace CarDealership;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<ServiceSale> ServiceSales { get; set; } = new List<ServiceSale>();
}
