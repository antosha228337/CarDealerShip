using System;
using System.Collections.Generic;

namespace CarDealership;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int StockCuantity { get; set; }

    public DateOnly? DateReceipt { get; set; }

    public int CarBrandId { get; set; }

    public int? DiscountId { get; set; }

    public byte[]? Image {  get; set; }

    public virtual CarBrand CarBrand { get; set; } = null!;

    public virtual Discount? Discount { get; set; }

    public virtual ICollection<Modification> Modifications { get; set; } = new List<Modification>();
}
