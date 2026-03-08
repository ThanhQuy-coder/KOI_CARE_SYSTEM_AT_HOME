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
        Task<Account?> AddAccount(Account account);
        Task<Account?> checkAccount(string email, string password);
        Task<List<Account>> GetAllAccount();
        Task<bool> DelAccount(Guid Id);
        Boolean DelAccount(Account account);
        Task<bool> UpdateAccount(Account account);
        Task<Account?> GetAccountById(Guid? Id);
    }
}
