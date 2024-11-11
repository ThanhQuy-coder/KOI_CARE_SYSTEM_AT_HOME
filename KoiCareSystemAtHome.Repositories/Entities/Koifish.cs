using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class KoiFish
{
    public Guid PondId { get; set; }

    public Guid FishId { get; set; }

    public string NameFish { get; set; } = null!;

    public string ImageFish { get; set; } = null!;

    public string BodyShape { get; set; } = null!;

    public int AgeFish { get; set; }

    public double Size { get; set; }

    public double WeightFish { get; set; }

    public string Gender { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public string Origin { get; set; } = null!;

    public double Price { get; set; }

    public int FishLocation { get; set; }

    public virtual ICollection<FeedingSchedule> FeedingSchedules { get; set; } = new List<FeedingSchedule>();

    public virtual Pond Pond { get; set; } = null!;
}
