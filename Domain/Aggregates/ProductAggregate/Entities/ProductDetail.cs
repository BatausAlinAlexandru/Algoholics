namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class ProductDetail
    {
        public Guid Id { get; set; }
        public string Name { set; get; }
        public float Price { set; get; }
        public string Description { set; get; }
        public ProductDetail(string name, float price, string description)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;

        }
        public void UpdateProductDetails(string name, float pret, string descriere)
        {
            this.Name = name;
            this.Price = pret;
            this.Description = descriere;
        }
    }
}
