using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly InventoryApiDbContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public ProductService(InventoryApiDbContext context, IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        

        public async Task<Product> GetProductAsync(Guid productId)
        {
            var entity = await _context.Products.SingleOrDefaultAsync(x => x.ProductId == productId);

            if (entity == null)
            {
                return null;
            }
            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<Product>(entity);

        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var query = _context.Products.ProjectTo<Product>(_mappingConfiguration);

            return await query.ToArrayAsync();
        }

        public async Task<Guid> PostProductAsync(Guid userId, ProductEntity product)
        {
             _context.Products.Add(product);
             var added=await _context.SaveChangesAsync();
            if (added < 1) throw new InvalidOperationException("Could not add new product");

            return product.ProductId;

           // throw new NotImplementedException();
        }
        public async Task DeleteProductAsync(Guid productId)
        {
            var products = await _context.Products.SingleOrDefaultAsync(x=>x.ProductId==productId);
            if (products == null) return;
            
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> AddProductAsync(Guid productId, int quantity)
        {
            var products = await _context.Products.SingleOrDefaultAsync(x => x.ProductId == productId);
            if (products == null) throw new InvalidOperationException("Product Not Found");

            products.AvailableQuantity = products.AvailableQuantity + quantity;

            _context.Update(products);
            throw new NotImplementedException();
        }
    }
}
