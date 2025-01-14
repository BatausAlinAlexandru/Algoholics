using Domain.Aggregates.UserAggregate.Entities;

namespace Application.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserAccountCredentials user);

    }
}
