﻿using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.WebApplication.Models;

public partial class SaltCalculation
{
    public string? PondId { get; set; }

    public double? RequiredSaltAmount { get; set; }

    public DateTime CalculationTime { get; set; }

    public virtual Pond? Pond { get; set; }
}
