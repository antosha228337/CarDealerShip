using System;
using System.Collections.Generic;

namespace DAL;

public partial class CarBrand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
