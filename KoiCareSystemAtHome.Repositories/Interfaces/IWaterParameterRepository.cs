using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface IWaterParameterRepository
    {
        Task<List<WaterParameter>> GetAllWaterParameter();
        Boolean DelWaterParameter(int Id);
        Boolean DelWaterParameter(WaterParameter WaterParameter);
        Boolean AddWaterParameter(WaterParameter WaterParameter);
        Boolean UppWaterParameter(WaterParameter WaterParameter);
        Task<WaterParameter> GetWaterParameterById(int Id);
    }
}
