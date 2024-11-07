﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoiCareSystemAtHome.Repositories.Entities;

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

    public string? IdWaterParameter { set; get; } = null!;

    public virtual Pond? Pond { get; set; }
}
