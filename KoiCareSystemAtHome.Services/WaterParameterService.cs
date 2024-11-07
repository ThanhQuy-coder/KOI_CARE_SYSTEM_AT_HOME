using KoiCareSystemAtHome.Repositories;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services
{
    public class WaterParameterService : IWaterParameterService
    {
        private readonly IWaterParameterRepository _repository;
        public WaterParameterService(IWaterParameterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<WaterParameter>> WaterParameters()
        {
            return await _repository.GetAllWaterParameters();
        }
    }
}

