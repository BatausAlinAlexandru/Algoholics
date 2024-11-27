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
        public ProductCategory ProductCategory { get; set; }
        public List<ProductSpecificationDTO> ProductSpecifications { get; set; }
    }
}
