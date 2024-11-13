using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class Pond
{
    public Guid? UserId { get; set; }

    public Guid PondId { get; set; }

    public string NamePond { get; set; } = null!;

    public string ImagePond { get; set; } = null!;

    public double Depth { get; set; }

    public double Volume { get; set; }

    public int DrainCount { get; set; }

    public double PumpCapacity { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual ICollection<SaltCalculation> SaltCalculations { get; set; } = new List<SaltCalculation>();

    public virtual User? User { get; set; }

    public virtual ICollection<WaterParameter> WaterParameters { get; set; } = new List<WaterParameter>();
}
