using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;

namespace KoiCareSystemAtHome.Services.Services
{
    public class KoiFishService : IKoiFishService
    {
        public Task<int> AddKoiFishAsync(object KoiFish)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteKoiFishAsync(int KoiFishId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Koifish>> GetKoiFishAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Koifish>> KoiFishes()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateKoiFishAsync(Koifish KoiFish)
        {
            throw new NotImplementedException();
        }
    }
}
