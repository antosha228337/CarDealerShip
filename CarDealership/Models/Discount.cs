using System;
using System.Collections.Generic;

namespace CarDealership;

public partial class Discount
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public float Percentage { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
