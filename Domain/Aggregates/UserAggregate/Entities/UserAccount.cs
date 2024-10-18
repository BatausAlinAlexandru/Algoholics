using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccount : BaseEntity,  IAggregateRoot
    {
        UserAccountSettings userAccountSettings { get; set; }

        public Role role { get; set; } = Role.User;

        public UserAccount(): base()
        {
            userAccountSettings = new UserAccountSettings();
        }

        public void SetUserAccountSettings(UserAccountSettings userAccountSettings)
        {
            this.userAccountSettings = userAccountSettings;
        }


    }
}
