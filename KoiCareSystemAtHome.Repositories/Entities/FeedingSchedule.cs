using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class FeedingSchedule
{
    public Guid ScheduleId { get; set; }

    public Guid FishId { get; set; }

    public DateTime FeedingTime { get; set; }

    public decimal RequiredFoodAmount { get; set; }

    public string FoodType { get; set; } = null!;

    public virtual KoiFish Fish { get; set; } = null!;
}
