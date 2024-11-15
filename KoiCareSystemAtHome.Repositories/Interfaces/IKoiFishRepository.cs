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
        Task<List<KoiFish>> GetAllKoiFish();
        Boolean AddKoiFish(KoiFish koiFish);
        Boolean DeleteKoiFish(Guid Id);
        Boolean DeleteKoiFish(KoiFish koiFish);
        Task<KoiFish> GetKoiFishById(Guid Id);
        Boolean UpdateKoiFish(KoiFish koifish);

    }
}
