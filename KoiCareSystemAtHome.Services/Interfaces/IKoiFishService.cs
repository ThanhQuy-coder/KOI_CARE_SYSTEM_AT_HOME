using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface IKoiFishService
    {
        Task<int> AddKoiFishAsync(object KoiFish);
        Task<bool> DeleteKoiFishAsync(int KoiFishId);
        Task<int> UpdateKoiFishAsync(Koifish KoiFish);
        Task SaveChangesAsync();
        Task<List<Koifish>> KoiFishes();
        Task<List<Koifish>> GetKoiFishAsync();
    }
}
