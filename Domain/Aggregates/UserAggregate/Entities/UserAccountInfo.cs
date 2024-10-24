namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccountInfo
    {
        public Guid Id { get; set; }
        public DateOnly DateCreated { get; set; }
        public string Sex { get; set; }
        public string Alias { get; set; }

        public UserAccountPaymantInfo paymentCardInfo { get; set; }

        public UserAccountInfo(string sex, string alias)
        {
            this.Sex = sex;
            this.Alias = alias;
            this.DateCreated = DateOnly.FromDateTime(DateTime.Now);

        }
        public UserAccountInfo()
        {
        }

        public void AddPaymentInfo(UserAccountPaymantInfo userAccountPaymantInfo)
        {
            this.paymentCardInfo.Id = this.Id;
            this.paymentCardInfo.CardNumber = userAccountPaymantInfo.CardNumber;
            this.paymentCardInfo.CardHolderName = userAccountPaymantInfo.CardHolderName.ToString(); //tostring e inutil in acest context
            this.paymentCardInfo.CVV = userAccountPaymantInfo.CVV;
        }
    }
}
