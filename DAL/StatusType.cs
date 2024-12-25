namespace DAL;

public partial class StatusType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

