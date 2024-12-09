namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class ProductSpecification
    {
        public string Key { get; set; }
        public string Value { get; set; }
            
        public ProductSpecification(string key, string value)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            Key = key;
            Value = value;
        }
    }
}
