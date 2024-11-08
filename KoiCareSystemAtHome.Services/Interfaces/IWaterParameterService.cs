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
        Boolean DelWaterParameter(int Id);
        Boolean DelWaterParameter(WaterParameter parameter);
        Boolean AddWaterParameter(WaterParameter parameter);
        Boolean UppWaterParameter(WaterParameter parameter);
        Task<WaterParameter> GetWaterParameterById(int Id);
    }
}
