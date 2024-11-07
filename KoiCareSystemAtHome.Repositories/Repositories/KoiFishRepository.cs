using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class KoiFishRepository : IKoiFishRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;
        public KoiFishRepository(KoiCareSystemAtHomeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddKoiFish(KoiFish koiFish)
        {
            try
            {

            }catch (Exception ex)
            {
                _dbContext.Koifishes.Add(koiFish);
                //await _dbContext.Koifishes.AddAsync(koiFish);
                _dbContext.SaveChanges();
                return true;
            }
            throw new NotImplementedException();
        }

        public bool DeleteKoiFish(string Id)
        {
            try
            {
                var objDel = _dbContext.Koifishes.Where(p => p.FishId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Koifishes.Remove(objDel);
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

        public bool DeleteKoiFish(KoiFish koiFish)
        {
            
            try
            {
                _dbContext.Koifishes.Remove(koiFish);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<KoiFish>> GetAllKoiFish()
        {
            return await _dbContext.Koifishes.ToListAsync();
        }

        public async Task<KoiFish> GetKoiFishById(string Id)
        {
            return await _dbContext.Koifishes.Where(p=>p.FishId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdateKoiFish(KoiFish koifish)
        {
            try
            {
                _dbContext.Koifishes.Update(koifish);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
