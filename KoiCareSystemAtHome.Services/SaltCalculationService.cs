using KoiCareSystemAtHome.Repositories;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services
{
    public class SaltCalculationService : ISaltCalculationService
    {
        private readonly ISaltCalculationRepository _repository;
        public SaltCalculationService(ISaltCalculationRepository repository)
        {
            _repository = repository;
        }

        public Task<List<SaltCalculation>> SaltCalculation()
        {
            return _repository.GetAllISaltCalculation();
        }
    }
}
