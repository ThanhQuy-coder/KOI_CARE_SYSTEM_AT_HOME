using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Services
{
	public class KoiFishService : IKoiFishService
	{
		private readonly IKoiFishRepository _repository;
		public KoiFishService(IKoiFishRepository repository)
		{
			_repository = repository;
		}
		public async Task<int> AddKoiFishAsync(KoiFish koifish)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteKoiFishAsync(int koiFishId)
		{
			throw new NotImplementedException();
		}

        public async Task DeleteKoiFishAsync(KoiFish koiFish)
        {
            throw new NotImplementedException();
        }

        public async Task<List<KoiFish>> GetKoifishAsync()
		{
			return await _repository.GetKoiFish();
		}

        public async Task<IList<KoiFish>> KoiFishes()
        {
            return await _repository.GetKoiFish();
        }


        public Task<int> RemoveKoiFishAsync(int koiFishId)
		{
			throw new NotImplementedException();
		}

        public async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateKoiFishAsync(KoiFish koifish)
		{
			throw new NotImplementedException();
		}
	}
}
