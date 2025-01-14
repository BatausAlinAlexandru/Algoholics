using Domain.Aggregates.UserAggregate.Value_Objects;

namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccountInfo
    {
        public Guid Id { get; set; }
        public DateOnly DateCreated { get; }
        public UserAccountGender UserAccountGender { get; set; }
        public string Alias { get; set; }
        public string Avatar { get; set; }
        public UserAccountPaymentInfo UserAccountPaymentCardInfo { get; set; } = new UserAccountPaymentInfo();

        public void AddPaymentInfo(UserAccountPaymentInfo userAccountPaymentInfo)
        {
            UserAccountPaymentCardInfo.UpdatePaymentInfo(userAccountPaymentInfo);
            UserAccountPaymentCardInfo.IdUserAccount = Id;
        }

        public void UpdatePaymentInfo(UserAccountPaymentInfo newUserAccountPaymentInfo)
        {
            UserAccountPaymentCardInfo.UpdatePaymentInfo(newUserAccountPaymentInfo);
        }

        public UserAccountInfo(UserAccountGender userAccountGender, string alias)
        {
            this.UserAccountGender = userAccountGender;    
            this.Alias = alias;
            this.DateCreated = DateOnly.FromDateTime(DateTime.Now);
            this.Avatar = "default_avatar.jpg";

        }
        public UserAccountInfo()
        {
            this.UserAccountGender = UserAccountGender.Other;
            this.Alias = "None";
            this.DateCreated = DateOnly.FromDateTime(DateTime.Now);
            this.Avatar = "default_avatar.jpg";
        }
    }
}
