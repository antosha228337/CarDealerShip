using System;
using System.Collections.Generic;

namespace CarDealership;

public partial class EngineType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Modification> Modifications { get; set; } = new List<Modification>();
}
