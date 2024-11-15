using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly KoiCareSystemAtHomeContext _dbContext;
        public AccountRepository(KoiCareSystemAtHomeContext dbContext) {
            _dbContext = dbContext;
        }

        public bool AddAccount(Account account)
        {
            try
            {
                _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool checkAccount(string email, string password)
        {
            try
            {
                foreach (var account in _dbContext.Accounts)
                {
                    if (email == account.Email && password == account.PassWordHash)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelAccount(Guid Id)
        {
            try
            {
                var objDel = _dbContext.Accounts.Where(p=>p.AccountId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbContext.Accounts.Remove(objDel);
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
        public bool DelAccount(Account account)
        {
            try
            {
                _dbContext.Remove(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<Account?> GetAccountById(Guid? Id)
        {
            return await _dbContext.Accounts.Where(p => p.AccountId.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task<List<Account>> GetAllAccount()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                _dbContext.Accounts.Update(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}
