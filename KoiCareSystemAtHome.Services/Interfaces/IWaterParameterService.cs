using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface IWaterParameterService
    {
        Task<List<WaterParameter>> GetAllWaterParameter();
        Boolean DelWaterParameter(Guid Id);
        Boolean DelWaterParameter(WaterParameter WaterParameter);
        Boolean AddWaterParameter(WaterParameter WaterParameter);
        Boolean UppWaterParameter(WaterParameter WaterParameter);
        Task<WaterParameter> GetWaterParameterById(Guid Id);
    }
}
