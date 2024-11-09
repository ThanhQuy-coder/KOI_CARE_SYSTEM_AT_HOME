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
        Task<List<FeedingSchedule>> getFeedingScheduleAsnyc();
        Task<int> AddFeedingScheduleAsync(FeedingSchedule feedingSchedule);
        Task<int> RemoveFeedingScheduleAsync(int feedingScheduleId);
        Task<bool> DeleteFeedingScheduleAsync(int feedingSchedule);
        Task<int> UpdateFeedingSchedule(FeedingSchedule feedingSchedule);
    }
}
