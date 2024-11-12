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
        Boolean DelWaterParameter(Guid Id);
        Boolean DelWaterParameter(WaterParameter waterParameter);
        Boolean AddWaterParameter(WaterParameter waterParameter);
        Boolean UppWaterParameter(WaterParameter waterParameter);
        Task<WaterParameter> GetWaterParameterById(Guid Id);
        //ham tinh toan
    }
}
