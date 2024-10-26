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
            private readonly List<DetaliiProduct> products = new List<DetaliiProduct>();

            // Method to add a new Product
            public void AddProduct(DetaliiProduct product)
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));

                products.Add(product);
            }

          
            public bool UpdateProduct(DetaliiProduct product, string name, string description, decimal price, int stockQuantity, string category)
            {
                if (product == null || !products.Contains(product))
                    return false;

                product.Update(name, description, price, stockQuantity, category);
                return true;
            }
            public bool DeleteProduct(DetaliiProduct product)
            {
                return products.Remove(product);
            }

            public DetaliiProduct GetProductByName(string name)
            {
                return products.FirstOrDefault(p => p.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
