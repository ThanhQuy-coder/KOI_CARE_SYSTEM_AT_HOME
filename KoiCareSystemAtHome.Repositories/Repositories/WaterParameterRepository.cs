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

        public bool AddWaterParameter(WaterParameter waterParameter)
        {
            try
            {
                _dbContext.WaterParameters.Add(waterParameter);
                _dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể thêm cá do trùng dữ liệu !: {ex.Message}");
                return false;
            }

        }

        public bool DelWaterParameter(WaterParameter waterParameter)
        {
            try
            {
                _dbContext.WaterParameters.Remove(waterParameter);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi, không thể xóa bằng Id ! {ex.Message}");
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
            return await _dbContext.WaterParameters
                .Include(k => k.Pond) // Sử dụng Include để nạp đối tượng Pond
                .ToListAsync();
        }

        public async Task<WaterParameter> GetWaterParameterById(Guid Id)
        {
            return await _dbContext.WaterParameters.Where(p => p.WaterParameterId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UppWaterParameter(WaterParameter waterParameter)
        {
            try
            {
                _dbContext.WaterParameters.Update(waterParameter);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi, không thể cập nhật: {ex.Message}");
                return false;
            }         
        }
        // dinh nghia ham tinh toan
    }
}
