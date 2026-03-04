using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserProfile>> GetAllUser();
        Boolean DelUser(Guid Id);
        Boolean DelUser(UserProfile user);
        Boolean AddUser(UserProfile user);
        Boolean UpdateUser(UserProfile user);
        Task<UserProfile?> GetUserById(Guid? Id);

        Boolean CheckUser(Guid AccountId,ref Guid UserId);
    }
}
