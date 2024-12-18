﻿using KoiCareSystemAtHome.Repositories;
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

        public bool AddSaltCalculation(SaltCalculation SaltCalculation)
        {
            return _repository.AddSaltCalculation(SaltCalculation);
        }

        public bool DelSaltCalculation(Guid Id)
        {
            return _repository.DelSaltCalculation(Id);
        }

        public bool DelSaltCalculation(SaltCalculation SaltCalculation)
        {
            return _repository.DelSaltCalculation(SaltCalculation);
        }

        public Task<List<SaltCalculation>> GetAllSaltCalculation()
        {
            return _repository.GetAllSaltCalculation();
        }

        public Task<SaltCalculation?> GetSaltCalculationById(Guid? Id)
        {
            return _repository.GetSaltCalculationById(Id);
        }

        public bool UpdateSaltCalculation(SaltCalculation SaltCalculation)
        {
            return _repository.UpdateSaltCalculation(SaltCalculation);
        }
        public async Task<SaltCalculation> InitializeKoiFish(Guid pondId)
        {
            // Khởi tạo đối tượng KoiFish với PondId được truyền vào
            return await Task.FromResult(new SaltCalculation { PondId = pondId });
        }

    }
}
