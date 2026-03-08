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

        public AccountRepository(KoiCareSystemAtHomeContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new account to the database asynchronously.
        /// </summary>
        /// <param name="account">The account entity to be added.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result is true if the account was successfully saved; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when an error occurs while adding or saving the account.
        /// </exception>
        public async Task<Account?> AddAccount(Account account)
        {
            try
            {
                await _dbContext.Accounts.AddAsync(account);
                await _dbContext.SaveChangesAsync();
                return account;
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message;
                throw new Exception($"Lỗi DB: {inner}");
            }
        }

        /// <summary>
        /// Checks whether an account exists in the database with the specified email and password.
        /// </summary>
        /// <param name="email">The email address of the account to verify.</param>
        /// <param name="password">The plain text or hashed password used for verification.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains the matching <see cref="Account"/> if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when an error occurs while querying the database.
        /// </exception>
        public async Task<Account?> checkAccount(string email, string password)
        {
            try
            {
                var account = await _dbContext.Accounts
                    .FirstOrDefaultAsync(a => a.Email == email && a.PasswordHash == password);

                return account;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra tài khoản trong cơ sở dữ liệu", ex);
            }
        }

        /// <summary>
        /// Deletes an account from the database by its unique identifier.
        /// </summary>
        /// <param name="Id">The unique identifier (GUID) of the account to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result is true if the account was successfully deleted; otherwise, false.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when an error occurs while attempting to delete the account from the database.
        /// </exception>
        public async Task<bool> DelAccount(Guid Id)
        {
            try
            {
                var account = await _dbContext.Accounts.FindAsync(Id);
                if (account == null) return false;

                _dbContext.Accounts.Remove(account);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa tài khoản trong cơ sở dữ liệu", ex);
            }
        }

        // ! Must change
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

        /// <summary>
        /// Retrieves an account from the database by its unique identifier.
        /// </summary>
        /// <param name="Id">
        /// The unique identifier (GUID) of the account to retrieve. 
        /// If the value is null, the method returns null.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains the <see cref="Account"/> if found; otherwise, null.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when an error occurs while attempting to retrieve the account from the database.
        /// </exception>
        public async Task<Account?> GetAccountById(Guid? Id)
        {
            try
            {
                if (Id == null) return null;
                return await _dbContext.Accounts.FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin tài khoản trong cơ sở dữ liệu", ex);
            }
        }

        public async Task<Account?> GetAccountByEmail(string targetEmail)
        {
            if (targetEmail == null) return null;
            try
            {
                var account = _dbContext.Accounts
                  .FirstOrDefault(u => u.Email == targetEmail);

                return account;
            } catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin tài khoản trong cơ sở dữ liệu", ex);
            }
        }

        /// <summary>
        /// Retrieves all accounts from the database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains a list of <see cref="Account"/> objects retrieved from the database.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when an error occurs while attempting to retrieve the list of accounts from the database.
        /// </exception>
        public async Task<List<Account>> GetAllAccount()
        {
            try
            {
                return await _dbContext.Accounts.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách tài khoản trong cơ sở dữ liệu", ex);
            }
        }

        /// <summary>
        /// Updates an existing account in the database.
        /// </summary>
        /// <param name="account">
        /// The account entity with modified values to be updated in the database.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result is true if the account was successfully updated; otherwise, false.
        /// </returns>
        /// <exception cref="DbUpdateConcurrencyException">
        /// Thrown when a concurrency conflict occurs while attempting to update the account.
        /// </exception>
        public async Task<bool> UpdateAccount(Account account)
        {
            _dbContext.Entry(account).State = EntityState.Modified;
            try
            {
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
