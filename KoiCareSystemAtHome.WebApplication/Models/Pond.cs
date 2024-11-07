﻿using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.WebApplication.Models;

public partial class Pond
{
    public string? UserId { get; set; }

    public string PondId { get; set; } = null!;

    public string NamePond { get; set; } = null!;

    public string? ImagePond { get; set; }

    public double? Depth { get; set; }

    public double? Volume { get; set; }

    public int? DrainCount { get; set; }

    public double? PumpCapacity { get; set; }

    public virtual ICollection<Koifish> Koifishes { get; set; } = new List<Koifish>();

    public virtual User? User { get; set; }

    public virtual ICollection<WaterParameter> WaterParameters { get; set; } = new List<WaterParameter>();
}
