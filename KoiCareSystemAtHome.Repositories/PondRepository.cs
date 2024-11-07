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
    public class PondRepository : IPondRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContest;

        public PondRepository(KoiCareSystemAtHomeContext dbContest) 
        {
            _dbContest = dbContest;
        }

        public async Task<List<Pond>> GetAllPonds()
        {
            return await _dbContest.Ponds.ToListAsync();
        }
    }
}
