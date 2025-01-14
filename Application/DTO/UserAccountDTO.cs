using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Application.DTO
{
    public class UserAccountDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public UserAccountRole UserAccountRole { get; set; }
        public DateOnly DateCreated { get; set; }
        public UserAccountGender UserAccountGender { get; set; }
        public string Alias { get; set; }

    }
}
