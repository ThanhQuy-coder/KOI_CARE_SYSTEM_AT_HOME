using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.Services.Services
{
    public class FeedingScheduleService : IFeedingScheduleService
    {
        public Task<int> AddFeedingScheduleAsync(FeedingSchedule feedingSchedule)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFeedingScheduleAsync(int feedingScheduleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<FeedingSchedule>> getFeedingScheduleAsnyc()
        {
            throw new NotImplementedException();
        }

        public Task<List<FeedingSchedule>> GetFeedingSchedulesAsync()
        {
            throw new NotImplementedException();
        }
        public Task<int> RemoveFeedingScheduleAsync(int feedingScheduleId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateFeedingSchedule(FeedingSchedule feedingSchedule)
        {
            throw new NotImplementedException();
        }
    }
}


