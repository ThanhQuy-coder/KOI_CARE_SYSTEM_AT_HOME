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
        private readonly KoiCareSystemAtHomeContext  DbContext;
        public FeedingScheduleRepository(KoiCareSystemAtHomeContext dbContext)
        {
            DbContext = DbContext;
        }

        public async Task<List<FeedingSchedule>> GetFeedingSchedules()
        {
            List<FeedingSchedule> feedingSchedules = null;
            try
            {
                feedingSchedules = await DbContext.FeedingSchedules.ToListAsync();
            }
            catch (Exception ex)
            {
                feedingSchedules?.Add(new FeedingSchedule());
            }

            return feedingSchedules;
        }
    }
}

