using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccountSettings
    {
        public string UserAccountUsername { get; set; } = String.Empty;

        public UserAccountGender UserAccountGender { get; set; }

        public UserAccountSettings(string userAccountUsername)
        {
            UserAccountUsername = userAccountUsername;
        }
    }
}
