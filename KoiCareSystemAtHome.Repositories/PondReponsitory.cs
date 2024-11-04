using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystemAtHome.Repositories
{
    public class PondReponsitory : IPondReponsitory
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;
        public PondReponsitory(KoiCareSystemAtHomeContext _dbContext)
        {
            _dbContext = _dbContext;
        }

        public async Task<List<Pond>> GetAllPond()
        {
            return await _dbContext.Ponds.ToListAsync();
        }
    }
}
