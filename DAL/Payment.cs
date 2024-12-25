using System;
using System.Collections.Generic;

namespace DAL;

public partial class Payment
{
    public int Id { get; set; }

    public int Amount { get; set; }

    public DateOnly Date { get; set; }

    public int SaleId { get; set; }

    public virtual Sale Sale { get; set; } = null!;
}
