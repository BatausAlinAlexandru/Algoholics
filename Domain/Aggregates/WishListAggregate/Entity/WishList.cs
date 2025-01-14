namespace Domain.Aggregates.WishListAggregate.Entity
{
    public class WishList : BaseEntity, IAggregateRoot
    {
        public Guid UserAccountId { get; set; }
        public List<Guid> ProductsId { get; set; } = new List<Guid>();

        public WishList(Guid userAccountId, List<Guid> productsId)
        {
            UserAccountId = userAccountId;
            ProductsId = productsId;
        }
    }
}
