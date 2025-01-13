using CSharpFunctionalExtensions;
using Domain.Aggregates.UserAggregate.Entities;

namespace Domain.Aggregates.UserAggregate.Repositories
{
    public interface IUserAccountRepository
    {
        public Task<Result> AddUserAccountAsync(UserAccountCredentials userAccountCredentials);
        public Task<Result> UpdateUserAccountAsync(UserAccount userAccount);
        public Task<Result> DeleteUserAccountAsync(Guid idUserAccount);


        public Task<Result> AddUserAccountPaymentCardInfoAsync(Guid idUserAccount, UserAccountPaymentInfo userAccountPaymentInfo);

        public Task<List<UserAccount>> GetUserAccountsAsync();
        public Task<UserAccount?> GetUserAccountByIdAsync(Guid idUserAccount);     

        public Task SaveUserAccountAsync();

    }
}
