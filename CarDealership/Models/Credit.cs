using System;
using System.Collections.Generic;

namespace CarDealership;

public partial class Credit
{
    public int Id { get; set; }

    public float InterestRate { get; set; }

    public int Period { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
