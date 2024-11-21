using System;
using System.Collections.Generic;

namespace CarDealership;

public partial class Seller
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? ThirdName { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int WorkExperience { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
