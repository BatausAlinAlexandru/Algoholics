namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccountCredentials
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;

        public UserAccountCredentials(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
