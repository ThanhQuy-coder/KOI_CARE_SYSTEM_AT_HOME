using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService(IAccountRepository repository) {
            _repository = repository;
        } 
        public Task<List<Account>> GetAllAccount()
        {
            return _repository.GetAllAccount();
        }

        public bool AddAccount(Account account)
        {
            return _repository.AddAccount(account);
        }

        public bool DelAccount(Guid Id)
        {
            return _repository.DelAccount(Id);
        }

        public bool DelAccount(Account account)
        {
            return _repository.DelAccount(account);
        }

        public Task<Account?> GetAccountById(Guid? Id)
        {
            return _repository.GetAccountById(Id);
        }

        public bool UpdateAccount(Account account)
        {
            return _repository.UpdateAccount(account);
        }

        public bool checkAccount(string email, string password,ref Guid getId)
        {
            return _repository.checkAccount(email, password,ref getId);
        }
    }
}
