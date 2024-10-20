using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Application.User.DTO
{
    public class UserAccountDTO
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public UserAccountRole UserAccountRole { get; set; }
    }
}
