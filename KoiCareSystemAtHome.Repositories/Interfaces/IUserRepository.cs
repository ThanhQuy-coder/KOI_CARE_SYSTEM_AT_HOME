using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser();
        Boolean DelUser(Guid Id);
        Boolean DelUser(User user);
        Boolean AddUser(User user);
        Boolean UpdateUser(User user);
        Task<User?> GetUserById(Guid? Id);
        Boolean CheckUser(Guid AccountId,ref Guid UserId);
    }
}
