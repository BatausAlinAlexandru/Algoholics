using Domain.Aggregates.UserAggregate.Entities;
using Domain.Aggregates.UserAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Exceptions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    internal class UserAccountRepository : IUserAccountRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public UserAccountRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        
        public async Task<List<UserAccount>> GetUserAccountsAsync()
        {
            return await _applicationDbContext.Users.ToListAsync();
        }

        
        public async Task<UserAccount?> GetUserAccountByIdAsync(Guid idUserAccount)
        {
            return await _applicationDbContext.Users.FindAsync(idUserAccount);
        }

        
        public async Task<bool> AddUserAccountAsync(UserAccountCredentials userAccountCredentials)
        {
            try
            {
                UserAccount userAccount = new UserAccount(userAccountCredentials.Email, userAccountCredentials.Password);
                _applicationDbContext.Users.Add(userAccount);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new UserAccountException("An error occurred while adding the user account.", ex);
            }

        }

        public async Task<bool> UpdateUserAccountCredentialEmailAsync(Guid idUserAccount, string email)
        {
            var userAccount = _applicationDbContext.Users.Find(idUserAccount);
            if (userAccount is not null)
            {
                userAccount.UpdateUserAccountCredentialEmail(email);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateUserAccountCredentialPasswordAsync(Guid idUserAccount, string password)
        {
            var userAccount = _applicationDbContext.Users.Find(idUserAccount);
            if (userAccount is not null)
            {
                userAccount.UpdateUserAccountCredentialEmail(password);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUserAccountAsync(Guid idUserAccount)
        {
            var userAccount = await _applicationDbContext.Users.FindAsync(idUserAccount);
            if (userAccount is not null)
            {
                _applicationDbContext.Users.Remove(userAccount);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
