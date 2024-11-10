using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface IFeedingScheduleRepository
    {
        Task<List<FeedingSchedule>> GetAllFeedingSchedules();
        Boolean DelFeedingSchedule(int Id);
        Boolean DelFeedingSchedule(FeedingSchedule feeding);
        Boolean AddFeedingSchedule(FeedingSchedule feeding);
        Boolean UpdateFeedingSchedule(FeedingSchedule feeding);
        Task<FeedingSchedule?> GetFeedingScheduleById(int? Id);
    }
}
