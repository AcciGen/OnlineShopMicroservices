using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.API.Models;
using Product.API.Persistance;
using System;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductDbContext productDbContext) : ControllerBase
    {
        private readonly ProductDbContext _productDbContext = productDbContext;

        [HttpGet]
        public IEnumerable<ProductInfo> GetAll()
        {
            return [.. _productDbContext.Products];
        }

        [HttpPost]
        public async Task<ProductInfo> Create([FromBody] ProductInfo product)
        {
            var result = await _productDbContext.Products.AddAsync(product);

            await _productDbContext.SaveChangesAsync();

            return result.Entity;
        }

        [HttpPut("{id}")]
        public async Task<ProductInfo> Update(Guid id, [FromBody] ProductInfo product)
        {
            var result = await _productDbContext.Products.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            
            result.Name = product.Name;
            result.Description = product.Description;
            result.Price = product.Price;
            
            var res = _productDbContext.Products.Update(result).Entity;

            await _productDbContext.SaveChangesAsync();

            return res;
        }

        [HttpDelete("{id}")]
        public async Task<ProductInfo> Delete(Guid id)
        {
            var product = await _productDbContext.Products.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            var result = _productDbContext.Products.Remove(product).Entity;

            await _productDbContext.SaveChangesAsync();

            return result;
        }
    }
}
