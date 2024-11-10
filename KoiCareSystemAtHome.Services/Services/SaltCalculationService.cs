using KoiCareSystemAtHome.Repositories;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Services
{
    public class SaltCalculationService : ISaltCalculationService
    {
        private readonly ISaltCalculationRepository _repository;
        public SaltCalculationService(ISaltCalculationRepository repository)
        {
            _repository = repository;
        }

        public bool AddSaltCalculation(SaltCalculation salt)
        {
            return _repository.AddSaltCalculation(salt);
        }

        public bool DelSaltCalculation(int Id)
        {
            return _repository.DelSaltCalculation(Id);
        }

        public bool DelSaltCalculation(SaltCalculation salt)
        {
            return _repository.DelSaltCalculation(salt);
        }

        public Task<List<SaltCalculation>> GetAllSaltCalculation()
        {
            return _repository.GetAllSaltCalculation();
        }

        public Task<SaltCalculation?> GetSaltCalculationById(int? Id)
        {
            return _repository.GetSaltCalculationById(Id);
        }

        public bool UpdateSaltCalculation(SaltCalculation salt)
        {
            return _repository.UpdateSaltCalculation(salt);
        }
    }
}
