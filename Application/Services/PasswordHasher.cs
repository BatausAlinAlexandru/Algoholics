using Application.Services.Interfaces;
using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<UserAccountCredentials> _passwordHasher = new PasswordHasher<UserAccountCredentials>();

        public string Hash(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool Verify(string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
