using System;
using System.Collections.Generic;

namespace CarDealership;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CarBrandId { get; set; }

    public byte[]? Image {  get; set; }

    public virtual CarBrand CarBrand { get; set; } = null!;

    public virtual ICollection<Modification> Modifications { get; set; } = new List<Modification>();
}
