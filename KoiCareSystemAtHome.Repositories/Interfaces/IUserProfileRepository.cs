using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<List<UserProfile>> GetAllUser();
        Task<bool> DelUser(Guid Id);
        Boolean DelUser(UserProfile user);
        Task<bool> AddUser(UserProfile user);
        Task<bool> UpdateUser(UserProfile user);
        Task<UserProfile?> GetUserById(Guid? Id);
        Task<(bool IsExisted, UserProfile? UserProfile)> CheckUser(Guid AccountId);
    }
}
