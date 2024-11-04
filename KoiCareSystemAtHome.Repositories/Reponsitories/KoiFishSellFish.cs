using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;

namespace KoiCareSystemAtHome.Repositories.Reponsitories
{
    public class KoiFishSellFish : IKoiFishSellFish
    {
        public KoiFishSellFish()
        {
        }

        public Task<int> AddKoiFishAsync(object KoiFish)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteKoiFishAsync(int KoiFishId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Koifish>> GetKoiFish()
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
        Task<List<Koifish>> IKoiFishSellFish.GetKoiFish()
        {
            throw new NotImplementedException();
        }
    }
}
