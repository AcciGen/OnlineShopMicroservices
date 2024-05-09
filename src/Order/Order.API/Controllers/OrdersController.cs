using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.API.Models;
using Order.API.Persistance;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(OrderDbContext orderDbContext) : ControllerBase
    {
        private readonly OrderDbContext _orderDbContext = orderDbContext;

        [HttpGet]
        public IEnumerable<OrderInfo> GetAll()
        {
            return [.. _orderDbContext.Orders];
        }

        [HttpPost]
        public async Task<OrderInfo> Create([FromBody] OrderInfo order)
        {
            var result = await _orderDbContext.Orders.AddAsync(order);

            await _orderDbContext.SaveChangesAsync();

            return result.Entity;
        }

        [HttpPut("{id}")]
        public async Task<OrderInfo> Update(Guid id, [FromBody] OrderInfo order)
        {
            var result = await _orderDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();

            result.Quantity = order.Quantity;

            var res = _orderDbContext.Orders.Update(result).Entity;

            await _orderDbContext.SaveChangesAsync();

            return res;
        }

        [HttpDelete("{id}")]
        public async Task<OrderInfo> Delete(Guid id)
        {
            var order = await _orderDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            var result = _orderDbContext.Orders.Remove(order).Entity;

            await _orderDbContext.SaveChangesAsync();

            return result;
        }
    }
}
