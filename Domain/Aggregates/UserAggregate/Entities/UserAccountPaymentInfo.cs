namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccountPaymentInfo : BaseEntity
    {
        public Guid IdUserAccount { get; set; }
        public string CardNumber { get; set; } = String.Empty;
        public string CardHolderName { get; set; } = String.Empty;
        public int ExpirationCardMonth { get; set; }
        public int ExpirationCardYear { get; set; }
        public int CVV { get; set; }

        public UserAccountPaymentInfo() { }

        public UserAccountPaymentInfo(string cardNumber, string cardHolderName, int expDateMonth, int expDateYear, int cvv)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationCardMonth = expDateMonth;
            ExpirationCardYear = expDateYear;
            CVV = cvv;
        }

        public void UpdatePaymentInfo(UserAccountPaymentInfo newUserAccountPaymentInfo)
        {
            IdUserAccount = newUserAccountPaymentInfo.IdUserAccount;
            CardNumber = newUserAccountPaymentInfo.CardNumber;
            CardHolderName = newUserAccountPaymentInfo.CardHolderName;
            ExpirationCardMonth = newUserAccountPaymentInfo.ExpirationCardMonth;
            ExpirationCardYear = newUserAccountPaymentInfo.ExpirationCardYear;
            CVV = newUserAccountPaymentInfo.CVV;
        }

        public void UpdatePaymentInfo(string cardNumber, string cardHolderName, int expDateMonth, int expDateYear, int cvv)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationCardMonth = expDateMonth;
            ExpirationCardYear = expDateYear;
            CVV = cvv;
        }
    }
}
