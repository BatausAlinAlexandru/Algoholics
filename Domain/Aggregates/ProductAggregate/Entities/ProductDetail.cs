using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.ProductAggregate.Entities
{
    public class ProductDetail:BaseEntity
    {
        public string Name { set; get; }
        public decimal Price { set; get; }
        public string Description { set; get; }
        public ProductDetail(string name, decimal price, string description)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;

        }
        public void UpdateProductDetails(string name, decimal pret, string descriere)
        {
            this.Name = name;
            this.Price = pret;
            this.Description = descriere;
        }
    }
}
