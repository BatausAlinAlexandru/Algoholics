namespace Domain
{
    public class BaseEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
