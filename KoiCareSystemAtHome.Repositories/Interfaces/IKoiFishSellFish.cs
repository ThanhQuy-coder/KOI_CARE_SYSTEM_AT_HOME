using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface IKoiFishSellFish
    {
        Task<int> AddKoiFishAsync(object KoiFish);
        Task<bool> DeleteKoiFishAsync(int KoiFishId);
        Task<int> UpdateKoiFishAsync(Koifish KoiFish);
        Task SaveChangesAsync();
        Task<List<Koifish>> GetKoiFish();
    }
}
