using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
	public interface IKoiFishRepository
	{
        Task<int> AddKoiFishAsync(object koiFish);
        Task<bool> DeleteKoiFishAsync(int koiFishId);
        Task DeleteKoiFishAsync(KoiFish koiFish);
        Task<List<KoiFish>> GetKoiFish();
        Task<List<Pond>> GetPondsAsync();
        Task<int> RemoveKoiFishAsync(int koiFishId);
        Task SaveChangesAsync();
        Task<int> UpdateKoiFishAsync(KoiFish koifish);
    }
}
