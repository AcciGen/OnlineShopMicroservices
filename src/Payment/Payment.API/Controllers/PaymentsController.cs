using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Payment.API.Models;
using Payment.API.Persistance;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(PaymentDbContext paymentDbContext) : ControllerBase
    {
        private readonly PaymentDbContext _paymentDbContext = paymentDbContext;

        [HttpGet]
        public IEnumerable<PaymentInfo> GetAll()
        {
            return [.. _paymentDbContext.Payments];
        }

        [HttpPost]
        public async Task<PaymentInfo> Create([FromBody] PaymentInfo payment)
        {
            var result = await _paymentDbContext.Payments.AddAsync(payment);

            await _paymentDbContext.SaveChangesAsync();

            return result.Entity;
        }

        [HttpPut("{id}")]
        public async Task<PaymentInfo> Update(Guid id, [FromBody] PaymentInfo payment)
        {
            var result = await _paymentDbContext.Payments.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();

            result.Amount = payment.Amount;
            result.Method = payment.Method;

            var res = _paymentDbContext.Payments.Update(result).Entity;

            await _paymentDbContext.SaveChangesAsync();

            return res;
        }

        [HttpDelete("{id}")]
        public async Task<PaymentInfo> Delete(Guid id)
        {
            var payment = await _paymentDbContext.Payments.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception();
            var result = _paymentDbContext.Payments.Remove(payment).Entity;

            await _paymentDbContext.SaveChangesAsync();

            return result;
        }
    }
}
