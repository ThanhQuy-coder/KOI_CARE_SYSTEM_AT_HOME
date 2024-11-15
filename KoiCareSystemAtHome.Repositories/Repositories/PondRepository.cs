using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class PondRepository : IPondRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;

        public PondRepository(KoiCareSystemAtHomeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddPond(Pond pond)
        {
            try
            {
                _dbContext.Ponds.Add(pond);
                _dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể thêm hồ do trùng dữ liệu !: {ex.Message}");
                return false;
            }
        }

        public bool DeletePond(Guid Id)
        {
            try
            {
                var objDel = _dbContext.Ponds.FirstOrDefault(p => p.PondId.Equals(Id));
                if (objDel != null)
                {
                    _dbContext.Ponds.Remove(objDel);
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

        public bool DeletePond(Pond pond)
        {
            try
            {
                _dbContext.Ponds.Remove(pond);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi, không thể xóa !: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Pond>> GetAllPond()
        {
            return await _dbContext.Ponds
                .Include(k => k.User) // Sử dụng Include để nạp đối tượng User
                .ToListAsync();
        }

        public Task<Pond> GetPonById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pond> GetPondById(Guid id)
        {
            return await _dbContext.Ponds
                                   .Include(k => k.User) // Bao gồm cả hồ (Pond)
                                   .FirstOrDefaultAsync(k => k.PondId == id);
        }

        public bool UpdatePond(Pond pond)
        {
            try
            {
                _dbContext.Ponds.Update(pond);
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