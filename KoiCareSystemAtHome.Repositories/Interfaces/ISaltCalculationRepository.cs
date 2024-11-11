using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface ISaltCalculationRepository
    {
        Task<List<SaltCalculation>> GetAllSaltCalculation();
        Boolean DelSaltCalculation(int Id);
        Boolean DelSaltCalculation(SaltCalculation SaltCalculation);
        Boolean AddSaltCalculation(SaltCalculation SaltCalculation);
        Boolean UpdateSaltCalculation(SaltCalculation SaltCalculation);
        Task<SaltCalculation?> GetSaltCalculationById(int? Id);
    }
}
