namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccountSettings
    {
        public Guid Id { get; set; }
        public bool EmailNotifications { get; set; }
        public bool SMSNotifications { get; set; }

        public UserAccountSettings()
        {
            this.EmailNotifications = false;
            this.SMSNotifications = false;
        }

        public UserAccountSettings(bool emailNotification, bool smsNotification)
        {
            this.EmailNotifications = emailNotification;
            this.SMSNotifications = smsNotification;
        }
        
    }
}
