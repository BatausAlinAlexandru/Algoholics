namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class ProductFilter
    {
        public Guid IdFilterGroup { get; set; }
        public Guid IdFilterValue { get; set; }

        public ProductFilter(Guid idFilterGroup, Guid idFilterValue) 
        {
            IdFilterGroup = idFilterGroup;
            IdFilterValue = idFilterValue;
        }

        public void UpdateProductCategory(Guid newIdFilterGroup, Guid newIdFilterValue)
        {
            IdFilterGroup = newIdFilterGroup;
            IdFilterValue = newIdFilterValue;
        }
    }
}
