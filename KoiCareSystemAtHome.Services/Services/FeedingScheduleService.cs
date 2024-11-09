using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Repositories.Repositories;



namespace KoiCareSystemAtHome.Services.Services
{
    public class FeedingScheduleService : IFeedingScheduleService
    {
        private IFeedingScheduleRepository _feedingScheduleRepository;
        public FeedingScheduleService(IFeedingScheduleRepository feedingScheduleRepository)
        {
            _feedingScheduleRepository = feedingScheduleRepository;
        }
        public async Task<int> AddFeedingScheduleAsync(FeedingSchedule feedingSchedule)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFeedingScheduleAsync(int feedingScheduleId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FeedingSchedule>>GetFeedingScheduleAsync()
        {
            return await _feedingScheduleRepository.GetFeedingSchedules();
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


