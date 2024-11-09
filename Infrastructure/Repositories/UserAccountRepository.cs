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
            var userAccount = await _applicationDbContext.Users
                .Include(u => u.UserAccountCredentials)
                .Include(u => u.UserAccountSettings)
                .Include(u => u.UserAccountInfo)
                .FirstOrDefaultAsync(u => u.Id == idUserAccount);

            return userAccount;
        }

        
        public async Task<bool> AddUserAccountAsync(UserAccountCredentials userAccountCredentials)
        {
            try
            {
                UserAccount UserAccount = new UserAccount();
                UserAccountSettings userAccountSettings = new UserAccountSettings();
                UserAccountInfo userAccountInfo = new UserAccountInfo();

                UserAccount.AddUserAccountCredentials(userAccountCredentials);
                UserAccount.AddUserAccountInfo(userAccountInfo);
                UserAccount.AddUserAccountSettings(userAccountSettings);

                _applicationDbContext.Users.Add(UserAccount);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new UserAccountException("An error occurred while adding the user account.", ex);
            }

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

        public async Task SaveUserAccountAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public Task<List<UserAccount>> GetUserAccountsAsyncV2()
        {
            var userAccounts = _applicationDbContext.Users
                .Include(u => u.UserAccountCredentials)
                .Include(u => u.UserAccountSettings)
                .Include(u => u.UserAccountInfo)
                .ToList();

            return Task.FromResult(userAccounts);
        }

    }
}
