namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccountInfo
    {
        public Guid Id { get; set; }
        public DateOnly DateCreated { get; }
        public string Sex { get; set; }
        public string Alias { get; set; }
        public string Avatar { get; set; }

        public UserAccountInfo(string sex, string alias)
        {
            this.Sex = sex;
            this.Alias = alias;
            this.DateCreated = DateOnly.FromDateTime(DateTime.Now);
            this.Avatar = "default_avatar.jpg";

        }
        // default
        public UserAccountInfo()
        {
            this.Sex = "None";
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
