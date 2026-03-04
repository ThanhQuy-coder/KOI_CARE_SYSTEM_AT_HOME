using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class WaterParameter
{
    public Guid ParameterId { get; set; }

    public Guid PondId { get; set; }

    public decimal Temperature { get; set; }

    public decimal SaltLevel { get; set; }

    public decimal Ph { get; set; }

    public decimal Oxygen { get; set; }

    public decimal Nitrite { get; set; }

    public decimal Nitrate { get; set; }

    public decimal Phosphate { get; set; }

    public DateTime MeasurementTime { get; set; }

    public virtual Pond Pond { get; set; } = null!;
}
