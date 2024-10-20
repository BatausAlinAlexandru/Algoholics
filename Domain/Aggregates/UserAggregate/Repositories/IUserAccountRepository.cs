using Domain.Aggregates.UserAggregate.Entities;

namespace Domain.Aggregates.UserAggregate.Repositories
{
    public interface IUserAccountRepository
    {
        /// <summary>
        /// Returns all user accounts
        /// </summary>
        /// <returns>List of UserAccount</returns>
        public Task<List<UserAccount>> GetUserAccountsAsync();

        /// <summary>
        /// Returns a user account by its id
        /// </summary>
        /// <param name="idUserAccount">User id</param>
        /// <returns></returns>
        public Task<UserAccount?> GetUserAccountByIdAsync(Guid idUserAccount);

        /// <summary>
        /// Add a new user account to the database, using the provided credentials
        /// </summary>
        /// <param name="userAccountCredentials"></param>
        /// <returns></returns>
        public Task<bool> AddUserAccountAsync(UserAccountCredentials userAccountCredentials);

        /// <summary>
        /// Update user account credentials
        /// </summary>
        /// <param name="idUserAccount">Id user that will be updated</param>
        /// <param name="newUserAccountCredentials">New user account credentials</param>
        /// <returns></returns>
        public Task<bool> UpdateUserAccountCredentialEmailAsync(Guid idUserAccount, string email);

        public Task<bool> UpdateUserAccountCredentialPasswordAsync(Guid idUserAccount, string password);

        /// <summary>
        /// Delete a user account
        /// </summary>
        /// <param name="idUserAccount"></param>
        /// <returns></returns>
        public Task<bool> DeleteUserAccountAsync(Guid idUserAccount);
    }
}
