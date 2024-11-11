using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class SaltCalculation
{
    public Guid PondId { get; set; }

    public Guid SaltCalculationId { get; set; }

    public double? RequiredSaltAmount { get; set; }

    public DateTime CalculationTime { get; set; }

    public virtual Pond Pond { get; set; } = null!;
}
