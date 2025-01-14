using Application.Services.Interfaces;
using Domain.Aggregates.UserAggregate.Entities;
using Domain.Aggregates.UserAggregate.Repositories;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IUserAccountRepository userAccountRepository, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher)
        {
            _userAccountRepository = userAccountRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var userAccounts = await _userAccountRepository.GetUserAccountsAsync();
            var user = userAccounts.FirstOrDefault(u => u.UserAccountCredentials.Email == email);

            if (user == null || !_passwordHasher.Verify(password, user.UserAccountCredentials.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            return _jwtTokenGenerator.GenerateToken(user.UserAccountCredentials);
        }

        public async Task LogoutAsync(Guid userId)
        {
            // Implementation for logout can vary depending on how you handle sessions or tokens.
            // For now, we assume it's a no-op.
            await Task.CompletedTask;
        }

        public async Task RegisterAsync(string email, string password)
        {
            var hashedPassword = _passwordHasher.Hash(password);
            var userAccountCredentials = new UserAccountCredentials(email, hashedPassword);
            var userAccount = new UserAccount();
            userAccount.AddUserAccountCredentials(userAccountCredentials);

            await _userAccountRepository.AddUserAccountAsync(userAccountCredentials);
            await _userAccountRepository.SaveUserAccountAsync();
        }
    }
}
