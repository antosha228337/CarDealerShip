using System;
using System.Collections.Generic;

namespace DAL;

public partial class Customer
{
    public int Id { get; set; }

    public string FisrtName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? ThirdName { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
