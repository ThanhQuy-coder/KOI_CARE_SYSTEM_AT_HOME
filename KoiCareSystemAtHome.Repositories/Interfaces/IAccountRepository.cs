using KoiCareSystemAtHome.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account?> AddAccount(Account account);
        Task<Account?> checkAccount(string email, string password);
        Task<bool> DelAccount(Guid Id);
        Boolean DelAccount(Account account);
        Task<Account?> GetAccountById(Guid? Id);
        Task<List<Account>> GetAllAccount();
        Task<bool> UpdateAccount(Account account);
        Task<Account?> GetAccountByEmail(string targetEmail);
    }
}
