using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface ISaltCalculationService
    {
        Task<List<SaltCalculation>> GetAllSaltCalculation();
        Boolean DelSaltCalculation(int Id);
        Boolean DelSaltCalculation(SaltCalculation SaltCalculation);
        Boolean AddSaltCalculation(SaltCalculation SaltCalculation);
        Boolean UpdateSaltCalculation(SaltCalculation SaltCalculation);
        Task<SaltCalculation?> GetSaltCalculationById(int? Id);
    }
}
