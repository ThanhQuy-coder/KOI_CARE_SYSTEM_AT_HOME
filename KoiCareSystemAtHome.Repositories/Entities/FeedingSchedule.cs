using System;
using System.Collections.Generic;

namespace KoiCareSystemAtHome.Repositories.Entities;

public partial class FeedingSchedule
{
    public Guid? FishId { get; set; }
<<<<<<< HEAD

    public Guid FeedingScheduleId { get; set; }

=======

    public Guid FeedingScheduleId { get; set; }
>>>>>>> Nhanh6(3)-BLOGANDNEWS

    public DateTime FeedingTime { get; set; }

    public double RequiredFoodAmount { get; set; }

    public string FoodType { get; set; } = null!;

    public virtual KoiFish? Fish { get; set; }
<<<<<<< HEAD

=======
>>>>>>> Nhanh6(3)-BLOGANDNEWS
}
