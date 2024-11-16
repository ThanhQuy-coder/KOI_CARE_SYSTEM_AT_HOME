using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;
        public UserRepository(KoiCareSystemAtHomeContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public bool AddUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelUser(Guid Id)
        {
            try
            {
                var objDel = _dbContext.Users.Where(p => p.UserId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Users.Remove(objDel);
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

        public bool DelUser(User user)
        {
            try
            {
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<User?> GetUserById(Guid? Id)
        {
            return await _dbContext.Users.Where(p => p.UserId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool CheckUser(Guid AccountId,ref Guid UserId)
        {
            foreach (var user in _dbContext.Users)
            {
                if(AccountId == user.AccountId)
                {
                    UserId = user.UserId;
                    return true;
                }
            }
            return false;
        }
    }
}
