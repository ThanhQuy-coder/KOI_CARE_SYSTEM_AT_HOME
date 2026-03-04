using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class KoiFish
{
    public Guid FishId { get; set; }

    public Guid PondId { get; set; }

    public string FishName { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string? BodyShape { get; set; }

    public int? Age { get; set; }

    public decimal Size { get; set; }

    public decimal Weight { get; set; }

    public string? Gender { get; set; }

    public string? Breed { get; set; }

    public string? Origin { get; set; }

    public decimal? Price { get; set; }

    public string? FishLocation { get; set; }

    public virtual ICollection<FeedingSchedule> FeedingSchedules { get; set; } = new List<FeedingSchedule>();

    public virtual Pond Pond { get; set; } = null!;
}
