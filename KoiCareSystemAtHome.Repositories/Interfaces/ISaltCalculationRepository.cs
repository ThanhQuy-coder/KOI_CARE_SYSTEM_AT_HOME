using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    internal interface ISaltCalculationRepository
    {
        Task<List<SaltCalculation>> GetAllSaltCalculation();

    }
}
