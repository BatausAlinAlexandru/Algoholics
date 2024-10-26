using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.ProductAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Domain.Aggregates.ProductAggregate
    {
        public class Product
        {
            public List<ProductDetails> products { set; get; } = new List<ProductDetails>();


            public void AddProduct(ProductDetails product)
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));

                products.Add(product);
            }

          
            public bool UpdateProduct(ProductDetails product, string name, string description, decimal price, int stockQuantity, string category)
            {
                if (product == null || !products.Contains(product))
                    return false;

                product.Update(name, description, price, stockQuantity, category);
                return true;
            }
            public bool DeleteProduct(ProductDetails product)
            {
                return products.Remove(product);
            }

            public ProductDetails GetProductByName(string name)
            {
                return products.FirstOrDefault(p => p.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
