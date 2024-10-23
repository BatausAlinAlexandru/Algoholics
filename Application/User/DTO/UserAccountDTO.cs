using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Application.User.DTO
{
    public class UserAccountDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserAccountRole UserAccountRole { get; set; }

    }
}
