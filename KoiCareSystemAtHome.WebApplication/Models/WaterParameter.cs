using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.WebApplication.Models;

public partial class WaterParameter
{
    public string? PondId { get; set; }

    public double? Temperature { get; set; }

    public double? SaltLevel { get; set; }

    public double? PH { get; set; }

    public double? Oxygen { get; set; }

    public double? Nitrie { get; set; }

    public double? Nitrate { get; set; }

    public double? Phospate { get; set; }

    public DateTime MeasurementTime { get; set; }

    public string IdWaterParameter { get; set; } = null!;

    public virtual Pond? Pond { get; set; }
}
