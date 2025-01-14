using Domain.Aggregates.CategoryAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Entities;

namespace Application.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }  
        public int Discount { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid IdCtegory { get; set; }
        public Guid IdSubcategory { get; set; }
        public List<ProductFilter> Filters { get; set; }
    }
}
