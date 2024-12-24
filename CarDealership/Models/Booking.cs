using System;
using System.Collections.Generic;

namespace CarDealership;

public partial class Booking
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int CarId { get; set; }

    public int CustomerId { get; set; }

    public int StatusTypeId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual StatusType StatusType { get; set; } = null!;
}
