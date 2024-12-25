using System;
using System.Collections.Generic;

namespace DAL;

public partial class Car
{
    public int Id { get; set; }

    public string Vin { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public string CountryProduction { get; set; } = null!;

    public int ModificationId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Modification Modification { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
