using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class FeedingSchedule
{
    public Guid? FishId { get; set; }

    public Guid FeedingScheduleId { get; set; }


    public DateTime FeedingTime { get; set; }

    public double RequiredFoodAmount { get; set; }

    public string FoodType { get; set; } = null!;

    public virtual KoiFish? Fish { get; set; }

}
