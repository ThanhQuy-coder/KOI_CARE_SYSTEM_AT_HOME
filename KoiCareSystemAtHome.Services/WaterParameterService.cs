using KoiCareSystemAtHome.Repositories;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using System.Collections.Generic;
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

        public bool AddWaterParameter(WaterParameter parameter)
        {
            return _repository.AddWaterParameter(parameter);
        }

        public bool DelWaterParameter(int id)
        {
            return _repository.DelWaterParameter(id);
        }

        public bool DelWaterParameter(WaterParameter parameter)
        {
            return _repository.DelWaterParameter(parameter);
        }

        public Task<List<WaterParameter>> GetAllWaterParameter()
        {
            return _repository.GetAllWaterParameter();
        }

        public Task<WaterParameter> GetWaterParameterById(int id)
        {
            return _repository.GetWaterParameterById(id);
        }

        public bool UppWaterParameter(WaterParameter parameter)
        {
            return _repository.UppWaterParameter(parameter);
        }
    }
}
