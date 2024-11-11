using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface IPondService
    {
        Task<List<Pond>> GetAllPond();
        Boolean AddPond(Pond pond);
        Boolean DeletePond(string Id);
        Boolean DeletePond(Pond pond);
        Task<Pond> GetPondById(string Id);
        Boolean UpdatePond(Pond pond);
        Task GetKoiFishById(string id);
    }
}
