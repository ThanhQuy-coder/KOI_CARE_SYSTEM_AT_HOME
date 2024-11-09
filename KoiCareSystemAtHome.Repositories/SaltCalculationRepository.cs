using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;

namespace KoiCareSystemAtHome.Repositories
{
    public class SaltCalculationRepository : ISaltCalculationRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;

        public SaltCalculationRepository(KoiCareSystemAtHomeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SaltCalculation>> GetAllSaltCalculation()
        {
            return await _dbContext.SaltCalculation.ToListAsync();
        }
    }
}
