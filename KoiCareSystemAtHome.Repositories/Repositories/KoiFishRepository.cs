using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                _dbContext.Koifishes.Add(koiFish);
                _dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể thêm cá do trùng dữ liệu !: {ex.Message}");
                return false;
            }
        }

        public bool DeleteKoiFish(string Id)
        {
            try
            {
                var objDel = _dbContext.Koifishes.FirstOrDefault(p => p.FishId.Equals(Id));
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
                Console.WriteLine($"Lỗi, không thể xóa bằng Id ! {ex.Message}");
                return false;
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
                Console.WriteLine($"Lỗi, không thể xóa !: {ex.Message}");
                return false;
            }
        }

        public async Task<List<KoiFish>> GetAllKoiFish()
        {
            return await _dbContext.Koifishes.ToListAsync();
        }

        public async Task<KoiFish> GetKoiFishById(string Id)
        {
            return await _dbContext.Koifishes.FirstOrDefaultAsync(p => p.FishId.Equals(Id));
        }

        public bool UpdateKoiFish(KoiFish koifish)
        {
            try
            {
                _dbContext.Koifishes.Update(koifish);
                _dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi, không thể cập nhật: {ex.Message}");
                return false;
            }
        }
    }
}
