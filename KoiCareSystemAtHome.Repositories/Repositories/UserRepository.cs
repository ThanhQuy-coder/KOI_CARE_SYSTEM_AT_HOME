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

        public bool AddUser(UserProfile user)
        {
            try
            {
                _dbContext.UserProfiles.Add(user);
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
                var objDel = _dbContext.UserProfiles.Where(p => p.UserId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.UserProfiles.Remove(objDel);
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

        public bool DelUser(UserProfile user)
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

        public async Task<UserProfile?> GetUserById(Guid? Id)
        {
            return await _dbContext.UserProfiles.Where(p => p.UserId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<UserProfile>> GetAllUser()
        {
            return await _dbContext.UserProfiles.ToListAsync();
        }

        public bool UpdateUser(UserProfile user)
        {
            try
            {
                _dbContext.UserProfiles.Update(user);
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
            foreach (var user in _dbContext.UserProfiles)
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
