using System;

namespace SimplePay.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int PayerId { get; set; }
        public int PayeeId { get; set; }

        public User? Payer { get; set; }
        public User? Payee { get; set; }
    }
}
