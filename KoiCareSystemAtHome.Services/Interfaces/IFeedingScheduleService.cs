using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Services.Interfaces
{ 
    public interface IFeedingScheduleService
    {
        Task<List<FeedingSchedule>> GetAllFeedingSchedules();
        Boolean DelFeedingSchedule(Guid Id);
        Boolean DelFeedingSchedule(FeedingSchedule FeedingSchedule);
        Boolean AddFeedingSchedule(FeedingSchedule FeedingSchedule);
        Boolean UpdateFeedingSchedule(FeedingSchedule FeedingSchedule);
        Task<FeedingSchedule?> GetFeedingScheduleById(Guid? Id);
    }
}
