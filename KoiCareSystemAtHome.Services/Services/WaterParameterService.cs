using KoiCareSystemAtHome.Repositories;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Services
{
    public class WaterParameterService : IWaterParameterService
    {
        private readonly IWaterParameterRepository _repository;

        public WaterParameterService(IWaterParameterRepository repository)
        {
            _repository = repository;
        }

        public bool AddWaterParameter(WaterParameter WaterParameter)
        {
            return _repository.AddWaterParameter(WaterParameter);
        }

        public bool DelWaterParameter(Guid id)
        {
            return _repository.DelWaterParameter(id);
        }

        public bool DelWaterParameter(WaterParameter WaterParameter)
        {
            return _repository.DelWaterParameter(WaterParameter);
        }

        public Task<List<WaterParameter>> GetAllWaterParameter()
        {
            return _repository.GetAllWaterParameter();
        }

        public Task<WaterParameter> GetWaterParameterById(Guid id)
        {
            return _repository.GetWaterParameterById(id);
        }

        public bool UppWaterParameter(WaterParameter WaterParameter)
        {
            return _repository.UppWaterParameter(WaterParameter);
        }
        
        //        private double CalculateTemperatureScore(double temperature)
        //        {
        //            if (temperature >= 15 && temperature <= 25) return 1.0;  // tối ưu
        //            if (temperature < 10 || temperature > 30) return 0.0;    // không phù hợp
        //            return 1 - Math.Abs(20 - temperature) / 10.0;            // giá trị trung bình
        //        }

        //        private double CalculateSaltLevelScore(double saltLevel)
        //        {
        //            if (saltLevel >= 0.05 && saltLevel <= 0.15) return 1.0;
        //            if (saltLevel < 0.01 || saltLevel > 0.2) return 0.0;
        //            return 1 - Math.Abs(0.1 - saltLevel) / 0.1;
        //        }

        //        private double CalculatePHScore(double ph)
        //        {
        //            if (ph >= 7.0 && ph <= 8.5) return 1.0;
        //            if (ph < 6.0 || ph > 9.0) return 0.0;
        //            return 1 - Math.Abs(7.5 - ph) / 1.5;
        //        }

        //        private double CalculateOxygenScore(double oxygen)
        //        {
        //            if (oxygen >= 5) return 1.0;
        //            if (oxygen < 3) return 0.0;
        //            return oxygen / 5.0;
        //        }

        //        private double CalculateNitriteScore(double nitrite)
        //        {
        //            if (nitrite < 0.02) return 1.0;
        //            if (nitrite > 0.5) return 0.0;
        //            return 1 - nitrite / 0.5;
        //        }

        //        private double CalculateNitrateScore(double nitrate)
        //        {
        //            if (nitrate < 20) return 1.0;
        //            if (nitrate > 100) return 0.0;
        //            return 1 - nitrate / 100;
        //        }

        //        private double CalculatePhosphateScore(double phosphate)
        //        {
        //            if (phosphate < 0.05) return 1.0;
        //            if (phosphate > 0.5) return 0.0;
        //            return 1 - phosphate / 0.5;
        //        }
    }
}
