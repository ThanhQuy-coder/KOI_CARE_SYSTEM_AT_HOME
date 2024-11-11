using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;

namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class SaltCalculationRepository : ISaltCalculationRepository
    {
        private readonly KoiCareSystemAtHomeContext _DbContext;
        public SaltCalculationRepository(KoiCareSystemAtHomeContext dbContext)
        {
            _DbContext = dbContext;
        }
        public bool AddSaltCalculation(SaltCalculation SaltCalculation)
        {
            try
            {
                _DbContext.SaltCalculations.Add(SaltCalculation);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelSaltCalculation(int Id)
        {
            try
            {
                var objDel = _DbContext.SaltCalculations.Where(p => p.SaltCalculationId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _DbContext.SaltCalculations.Remove(objDel);
                    _DbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelSaltCalculation(SaltCalculation SaltCalculation)
        {
            try
            {
                _DbContext.Remove(SaltCalculation);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<SaltCalculation>> GetAllSaltCalculation()
        {
            return await _DbContext.SaltCalculations.ToListAsync();
        }

        public async Task<SaltCalculation?> GetSaltCalculationById(int? Id)
        {
            return await _DbContext.SaltCalculations.Where(p => p.SaltCalculationId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdateSaltCalculation(SaltCalculation SaltCalculation)
        {
            try
            {
                _DbContext.SaltCalculations.Update(SaltCalculation);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
