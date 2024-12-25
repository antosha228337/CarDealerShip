using System;
using System.Collections.Generic;

namespace DAL;

public partial class Modification
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Horsepower { get; set; }

    public float EngineCapacity { get; set; }

    public int Price { get; set; }

    public int ModelId { get; set; }

    public int TransmissionTypeId { get; set; }

    public int EngineTypeId { get; set; }

    public int DriveTypeId { get; set; }

    public int BodyTypeId { get; set; }

    public virtual BodyType BodyType { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual DriveType DriveType { get; set; } = null!;

    public virtual EngineType EngineType { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;

    public virtual TransmissionType TransmissionType { get; set; } = null!;
}
