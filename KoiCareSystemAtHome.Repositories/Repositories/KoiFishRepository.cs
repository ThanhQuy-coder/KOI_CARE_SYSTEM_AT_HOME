using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Repositories
{
	public class KoiFishRepository : IKoiFishRepository
	{
		private readonly KoiCareSystemAtHomeContext _dbContext;
		public KoiFishRepository(KoiCareSystemAtHomeContext dbContext)
		{
			_dbContext = dbContext;
		}

        public Task<int> AddKoiFishAsync(object koiFish)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteKoiFishAsync(int koiFishId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteKoiFishAsync(KoiFish koiFish)
        {
            throw new NotImplementedException();
        }

        public	async Task<List<KoiFish>> GetKoiFish()
		{
			List<KoiFish> koiFishes = null;
			try
			{
				koiFishes = await _dbContext.Koifishes.ToListAsync();

			}
			catch(Exception ex) 
			{
				koiFishes?.Add(new KoiFish());
			}
			return koiFishes;
			
		}

        public Task<List<Pond>> GetPondsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveKoiFishAsync(int koiFishId)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateKoiFishAsync(KoiFish koifish)
        {
            throw new NotImplementedException();
        }
    }
}
