using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.WebApplication.Models;

public partial class FeedingSchedule
{
    public string? FishId { get; set; }

    public DateTime FeedingTime { get; set; }

    public double RequiredFoodAmount { get; set; }

    public string FoodType { get; set; } = null!;

    public virtual Koifish? Fish { get; set; }
}
