using System;
using System.Collections.Generic;

namespace DAL;

public partial class TransmissionType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Modification> Modifications { get; set; } = new List<Modification>();
}
