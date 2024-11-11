using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class WaterParameterRepository : IWaterParameterRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;
        public WaterParameterRepository(KoiCareSystemAtHomeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddWaterParameter(WaterParameter WaterParameter)
        {
            try
            {
                _dbContext.WaterParameters.Add(WaterParameter);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }

        }

        public bool DelWaterParameter(WaterParameter WaterParameter)
        {
            try
            {
                _dbContext.WaterParameters.Remove(WaterParameter);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
                return false;
            }
        }

        public bool DelWaterParameter(Guid Id)
        {
            try
            {
                var objDel = _dbContext.WaterParameters.Where(p => p.WaterParameterId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.WaterParameters.Remove(objDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<WaterParameter>> GetAllWaterParameter()
        {
            return await _dbContext.WaterParameters.ToListAsync();
        }

        public async Task<WaterParameter> GetWaterParameterById(Guid Id)
        {
            return await _dbContext.WaterParameters.Where(p => p.WaterParameterId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UppWaterParameter(WaterParameter WaterParameter)
        {
            try
            {
                _dbContext.WaterParameters.Update(WaterParameter);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }         
        }
        // dinh nghia ham tinh toan
    }
}
