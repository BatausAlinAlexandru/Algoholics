using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class Product:BaseEntity,IAggregateRoot
    {
         
        public void AddProduct(ProductDetail product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            Products.Add(product);
        }


        public bool UpdateProduct(ProductDetail product, string name, string description, decimal price)
        {
            if (product == null || !Products.Contains(product))
                return false;

            product.UpdateProductDetails(name, price, description);
            return true;
        }
        public bool DeleteProduct(ProductDetail product)
        {
            return Products.Remove(product);
        }

        public ProductDetail GetProductByName(string name)
        {
            return Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}