using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(string name, float price, string description, int stoc, int disc, string pathFoto);
        public Task DeleteProductAsync(Guid IdProd);
        Task ModiftProductAsync(Guid productId, string name, float price, string description, int stoc, int disc, string pathFoto);
    }
}