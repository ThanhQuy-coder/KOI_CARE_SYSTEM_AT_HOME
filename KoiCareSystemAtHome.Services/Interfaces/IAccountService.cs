using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Interfaces
{
    public interface IAccountService
    {
        Task<List<Account>> GetAllAccount();
        Boolean DelAccount(Guid Id);
        Boolean DelAccount(Account account);
        Boolean AddAccount(Account account);
        Boolean UpdateAccount(Account account);
        Task<Account?> GetAccountById(Guid? Id);
        Boolean checkAccount(string email, string password,ref Guid getId);
    }
}
