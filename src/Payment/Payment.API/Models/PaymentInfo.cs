namespace Payment.API.Models
{
    public class PaymentInfo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Amount { get; set; }
        public string Method { get; set; }

    }
}
