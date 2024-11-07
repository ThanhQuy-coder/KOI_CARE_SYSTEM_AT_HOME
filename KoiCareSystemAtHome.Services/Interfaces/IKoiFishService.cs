using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface IKoiFishService
    {
        Task<List<KoiFish>> GetAllKoiFish();
        Boolean AddKoiFish(KoiFish koiFish);
        Boolean DeleteKoiFish(string Id);
        Boolean DeleteKoiFish(KoiFish koiFish);
        Task<KoiFish> GetKoiFishById(string Id);
        Boolean UpdateKoiFish(KoiFish koifish);
    }
}
