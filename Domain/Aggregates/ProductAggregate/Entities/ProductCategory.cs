namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class ProductCategory: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ProductCategory(string name, string description) 
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            
            this.Name = name;
            this.Description = description;
        }

        public void UpdateProductCategory(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            this.Name = name;
            this.Description = description;
        }
    }
}
