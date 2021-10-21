using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid productId);

        Task<Guid> PostProductAsync(Guid userId, ProductEntity product);

        Task DeleteProductAsync(Guid productId);

        Task<bool> AddProductAsync(Guid productId, int quantity);
    }
}
