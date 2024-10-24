namespace Domain.Aggregates.UserAggregate.Entities
{
    public class UserAccountPaymantInfo
    {
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public int CVV { get; set; }


        public UserAccountPaymantInfo(string cardNumber, string cardHolderName, DateOnly dateE, int cvv) {
            this.CardNumber = cardNumber;
            this.CardHolderName = cardHolderName;
            this.ExpiryDate = dateE;
            this.CVV = cvv;
        }

        public UserAccountPaymantInfo()
        {
        }

    }
}
