using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public interface FeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;
        public FeedingScheduleRepository(KoiCareSystemAtHomeContext _dbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<List<FeedingSchedule>> GetFeedingSchedules()
        {
            List<FeedingSchedule> feedingSchedules = null;
            try
            {
                feedingSchedules = await _dbContext.FeedingSchedules.ToListAsync();
            }
            catch (Exception ex)
            {
                feedingSchedules?.Add(new FeedingSchedule());
            }

            return feedingSchedules;
        }
    }
}

