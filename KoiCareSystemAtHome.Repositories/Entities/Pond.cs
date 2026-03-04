using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class Pond
{
    public Guid PondId { get; set; }

    public Guid UserId { get; set; }

    public string PondName { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public decimal Depth { get; set; }

    public decimal Volume { get; set; }

    public int DrainCount { get; set; }

    public decimal PumpCapacity { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual ICollection<SaltCalculation> SaltCalculations { get; set; } = new List<SaltCalculation>();

    public virtual UserProfile User { get; set; } = null!;

    public virtual ICollection<WaterParameter> WaterParameters { get; set; } = new List<WaterParameter>();
}
