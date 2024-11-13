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
        private readonly IFeedingScheduleRepository _repository;
        public FeedingScheduleService(IFeedingScheduleRepository repository)
        {
            _repository = repository;
        }
        public bool AddFeedingSchedule(FeedingSchedule FeedingSchedule)
        {
            return _repository.AddFeedingSchedule(FeedingSchedule);
        }

        public bool DelFeedingSchedule(Guid Id)
        {
            return _repository.DelFeedingSchedule(Id);
        }

        public bool DelFeedingSchedule(FeedingSchedule FeedingSchedule)
        {
            return _repository.DelFeedingSchedule(FeedingSchedule);
        }

        public Task<List<FeedingSchedule>> GetAllFeedingSchedules()
        {
            return _repository.GetAllFeedingSchedules();
        }

        public Task<FeedingSchedule?> GetFeedingScheduleById(Guid? Id)
        {
            return _repository.GetFeedingScheduleById(Id);
        }

        public bool UpdateFeedingSchedule(FeedingSchedule FeedingSchedule)
        {
            return _repository.UpdateFeedingSchedule(FeedingSchedule);
        }
        public async Task<FeedingSchedule> InitializeKoiFish(Guid fishId)
        {
            // Khởi tạo đối tượng KoiFish với PondId được truyền vào
            return await Task.FromResult(new FeedingSchedule { FishId = fishId });
        }
    }
}


