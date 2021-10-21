using InventoryManagement.Models;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name =nameof(GetAllProducts))]
        public async Task<ActionResult<Collection<Product>>> GetAllProducts()
        {
            var products = await _productService.GetProductsAsync();
            var collection = new Collection<Product>
            {
                Href = Url.Link(nameof(GetAllProducts), null),
                Value = products.ToArray()
            };

            return collection;
        }


        [HttpGet("{productid}",Name =nameof(GetProductById))]
        public async Task<ActionResult<Product>> GetProductById(Guid productid)
        {
            var products = await _productService.GetProductAsync(productid);

            if (products == null)
                return NotFound();

            return products;
        }

        [HttpPost ( "{post}",Name =nameof(PostProducts))]
        public async Task<ActionResult<Product>> PostProducts( [FromBody]PostForm addForm )
        {

            var product = new ProductEntity
            {
                ProductId=Guid.NewGuid(),
                Name=addForm.Name,
                Category=addForm.Category,
                Color=addForm.Color,
                UnitPrice=addForm.UnitPrice.GetValueOrDefault(),
            };

            var userId = new Guid();
            Guid productId=await _productService.PostProductAsync(userId,product);

            return Created(Url.Link(nameof(GetProductById), new { productId }), null);
        }



        //DELETE /Product/productId
        [HttpDelete("{productId}",Name =nameof(DeleteProduct))]
        public async Task<ActionResult> DeleteProduct(Guid productId)
        {
            await _productService.DeleteProductAsync(productId);
            return NoContent();
        }


        [Route("/[controller]/add")]
        [HttpPut("{add}", Name = nameof(AddProduct))]
        public async Task<IActionResult> AddProduct([FromBody] AddForm addForm)
        {
            var updated=await _productService.AddProductAsync(addForm.ProductId, addForm.Quantity.GetValueOrDefault());

            return Created(Url.Link(nameof(GetProductById), new { addForm.ProductId }), null);
        }
    }
}
