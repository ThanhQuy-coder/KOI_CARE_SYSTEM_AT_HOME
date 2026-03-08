using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;
        public UserProfileRepository(KoiCareSystemAtHomeContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<bool> AddUser(UserProfile user)
        {
            try
            {
                await _dbContext.UserProfiles.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DelUser(Guid id)
        {
            try
            {
                var userProfile = await _dbContext.UserProfiles.FindAsync(id);

                if (userProfile == null)
                {
                    return false;
                }

                _dbContext.UserProfiles.Remove(userProfile);

                await _dbContext.SaveChangesAsync();

                return true;
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

        public async Task<bool> UpdateUser(UserProfile user)
        {
            try
            {
                _dbContext.UserProfiles.Update(user);

                var result = await _dbContext.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<(bool IsExisted, UserProfile? UserProfile)> CheckUser(Guid AccountId)
        {
            var user = await _dbContext.UserProfiles
                .Where(u => u.AccountId == AccountId)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                return (true, user);
            }

            return (false, null);
        }
    }
}
