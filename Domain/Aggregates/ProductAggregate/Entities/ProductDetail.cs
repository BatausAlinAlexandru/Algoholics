namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class ProductDetail
    {   //stoc+discount+url
        public Guid Id { get; set; }
        public string Name { set; get; }
        public float Price { set; get; }
        public string Description { set; get; }
        public int Stoc { set; get; }
        public int Discount { set; get; }
        public string pathFoto { get; set; }

        public ProductDetail() { }
        public ProductDetail(string name, float price, string description,int stoc,int disc, string pathFoto)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.Discount = disc;
            this.Stoc = stoc;
            this.pathFoto = pathFoto;
        }
        public void UpdateProductDetails(string name, float price, string description, int stoc, int disc, string pathFoto)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.Discount = disc;
            this.Stoc = stoc;
            this.pathFoto = pathFoto;
        }
    }
}
