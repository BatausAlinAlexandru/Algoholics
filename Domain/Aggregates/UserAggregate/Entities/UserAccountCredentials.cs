using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccountCredentials
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserAccountRole UserAccountRole { get; set; } = UserAccountRole.User;

        public UserAccountCredentials()
        {
            this.Email = string.Empty;
            this.Password = string.Empty;
        }

        public UserAccountCredentials(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public void UpdateEmail(string email)
        {
            this.Email = email;
        }

        public void UpdatePassword(string password)
        {
            this.Password = password;
        }

        public void UpdateRole(UserAccountRole role)
        {
            this.UserAccountRole = role;
        }
    }
}
