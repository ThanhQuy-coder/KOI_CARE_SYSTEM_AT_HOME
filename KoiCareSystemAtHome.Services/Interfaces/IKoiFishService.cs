using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services
{
	public interface IKoiFishService
	{
		Task<List<KoiFish>> GetKoifishAsync();
		Task<int> AddKoiFishAsync(KoiFish koifish);
        Task<bool> DeleteKoiFishAsync(int koiFishId);
		Task<int> RemoveKoiFishAsync(int koiFishId);
		Task<int> UpdateKoiFishAsync(KoiFish koifish);
        Task<IList<KoiFish>> KoiFishes();
    }
}
