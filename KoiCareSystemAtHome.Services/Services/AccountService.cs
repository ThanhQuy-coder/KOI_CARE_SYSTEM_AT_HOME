using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services.Interfaces;
using BCrypt.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace KoiCareSystemAtHome.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Account>> GetAllAccount()
        {
            return await _repository.GetAllAccount();
        }

        public async Task<Account?> AddAccount(Account account)
        {
            // Hash Password
            account.PasswordHash = HashPassword(account.PasswordHash);
            return await _repository.AddAccount(account);
        }

        public async Task<bool> DelAccount(Guid Id)
        {
            return await _repository.DelAccount(Id);
        }

        public bool DelAccount(Account account)
        {
            return _repository.DelAccount(account);
        }

        public async Task<Account?> GetAccountById(Guid? Id)
        {
            return await _repository.GetAccountById(Id);
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            return await _repository.UpdateAccount(account);
        }

        public async Task<Account?> checkAccount(string email, string plainPassword)
        {
            var account = await _repository.GetAccountByEmail(email);

            if (account == null)
            {
                return null;
            }

            bool isValid = BCrypt.Net.BCrypt.Verify(plainPassword, account.PasswordHash);

            if (isValid)
            {
                return account;
            }

            return null;
        }

        // Function used to hash the password
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }
    }
}
