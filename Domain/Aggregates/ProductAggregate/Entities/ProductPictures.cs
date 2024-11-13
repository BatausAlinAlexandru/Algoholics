using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.ProductAggregate.Entities
{
  
    public class ProductPictures
    {
        public Guid Id { get; set; }
        public string Url { get; set; }

        public ProductPictures(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("Image URL cannot be empty.");
            }

            Id = Guid.NewGuid();
            Url = url;
        }

        public void UpdateUrl(string newUrl)
        {
            if (string.IsNullOrWhiteSpace(newUrl))
            {
                throw new ArgumentException("New URL cannot be empty.");
            }
            Url = newUrl;
        }
    }
}

