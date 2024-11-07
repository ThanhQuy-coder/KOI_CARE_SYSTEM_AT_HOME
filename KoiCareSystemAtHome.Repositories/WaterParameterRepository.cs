using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories
{
    public class WaterParameterRepository : IWaterParameterRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;
        public WaterParameterRepository(KoiCareSystemAtHomeContext dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task<List<WaterParameter>> GetAllWaterParameters()
        {
            return await _dbContext.WaterParameters.ToListAsync();
        }
    }
}
