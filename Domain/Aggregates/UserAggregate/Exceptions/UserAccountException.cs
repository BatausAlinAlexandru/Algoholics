namespace Domain.Aggregates.UserAggregate.Exceptions
{
    public class UserAccountException : Exception
    {
        public UserAccountException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
    }
}
