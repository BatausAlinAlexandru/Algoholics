using Domain.Aggregates.UserAggregate.Entities;
using Domain.Aggregates.UserAggregate.Repositories;
using Domain.Aggregates.UserAggregate.Exceptions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using CSharpFunctionalExtensions;


namespace Infrastructure.Repositories
{
    internal class UserAccountRepository : IUserAccountRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public UserAccountRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Result> AddUserAccountAsync(UserAccountCredentials userAccountCredentials)
        {
            try
            {
                UserAccount UserAccount = new UserAccount();
                UserAccountSettings userAccountSettings = new UserAccountSettings();
                UserAccountInfo userAccountInfo = new UserAccountInfo();

                userAccountInfo.UserAccountPaymentCardInfo = new UserAccountPaymentInfo();
                

                // ceva logica o rezolv dupa  //////////////////////////////////////////////////
                string usernameBase = userAccountCredentials.Email.Split("@")[0];
                int randomNumber = RandomNumberGenerator.GetInt32(1000, 9999);
                string username = $"{usernameBase}{randomNumber}";
                userAccountInfo.Alias = username;
                ////////////////////////////////////////////////////////////////////////////////


                UserAccount.AddUserAccountCredentials(userAccountCredentials);
                UserAccount.AddUserAccountInfo(userAccountInfo);
                UserAccount.AddUserAccountSettings(userAccountSettings);

                _applicationDbContext.Users.Add(UserAccount);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }

        }

        public async Task<Result> UpdateUserAccountAsync(UserAccount newUserAccount)
        {
            var user = await _applicationDbContext.Users.FindAsync(newUserAccount.Id);
            if (user is null)
                return Result.Failure("User not found");

            user.UpdateUserAccount(newUserAccount);
            await _applicationDbContext.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result> DeleteUserAccountAsync(Guid idUserAccount)
        {
            var userAccount = await _applicationDbContext.Users.FindAsync(idUserAccount);
            if (userAccount is not null)
            {
                _applicationDbContext.Users.Remove(userAccount);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            return Result.Failure("UserAccount Delete Error");
        }


        public async Task<Result> AddUserAccountPaymentCardInfoAsync(Guid idUserAccount, UserAccountPaymentInfo userAccountPaymentInfo)
        {
            var userAccount = await _applicationDbContext.Users
                .Include(u => u.UserAccountInfo)
                .FirstOrDefaultAsync(u => u.Id == idUserAccount);
            if (userAccount is null)
                return Result.Failure("User not found");

            userAccount.UserAccountInfo.AddPaymentInfo(userAccountPaymentInfo);

            await _applicationDbContext.SaveChangesAsync();
            return Result.Success();
        }


        public Task<List<UserAccount>> GetUserAccountsAsync()
        {
            var userAccounts = _applicationDbContext.Users
                .Include(u => u.UserAccountCredentials)
                .Include(u => u.UserAccountSettings)
                .Include(u => u.UserAccountInfo)
                .Include(u => u.UserAccountInfo.UserAccountPaymentCardInfo)
                .ToList();

            return Task.FromResult(userAccounts);
        }
       
        public async Task<UserAccount?> GetUserAccountByIdAsync(Guid idUserAccount)
        {
            var userAccount = await _applicationDbContext.Users
                .Include(u => u.UserAccountCredentials)
                .Include(u => u.UserAccountSettings)
                .Include(u => u.UserAccountInfo)
                .Include(u => u.UserAccountInfo.UserAccountPaymentCardInfo)
                .FirstOrDefaultAsync(u => u.Id == idUserAccount);

            return userAccount;
        }

        public async Task SaveUserAccountAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

    }
}
