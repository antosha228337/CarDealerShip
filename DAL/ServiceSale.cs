using System;
using System.Collections.Generic;

namespace DAL;

public partial class ServiceSale
{
    public int Id { get; set; }

    public int ServicePrice { get; set; }

    public int SaleId { get; set; }

    public int ServiceId { get; set; }

    public virtual Sale Sale { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
