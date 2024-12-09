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

        public UserAccountInfo(UserAccountGender userAccountGender, string alias)
        {
            this.UserAccountGender = userAccountGender;    
            this.Alias = alias;
            this.DateCreated = DateOnly.FromDateTime(DateTime.Now);
            this.Avatar = "default_avatar.jpg";

        }
        // default
        public UserAccountInfo()
        {
            this.UserAccountGender = UserAccountGender.Other;
            this.Alias = "None";
            this.DateCreated = DateOnly.FromDateTime(DateTime.Now);
            this.Avatar = "default_avatar.jpg";
        }

      /*  public void AddPaymentInfo(UserAccountPaymantInfo userAccountPaymantInfo)
        {
            this.paymentCardInfo.Id = this.Id;
            this.paymentCardInfo.CardNumber = userAccountPaymantInfo.CardNumber;
            this.paymentCardInfo.CardHolderName = userAccountPaymantInfo.CardHolderName.ToString(); //tostring e inutil in acest context
            this.paymentCardInfo.CVV = userAccountPaymantInfo.CVV;
        }*/
    }
}
