using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplePay.Data;
using SimplePay.Models;

namespace SimplePay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            var payments = _context.Payments
                .Include(p => p.Payer)
                .Include(p => p.Payee)
                .ToList();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var payment = _context.Payments
                .Include(p => p.Payer)
                .Include(p => p.Payee)
                .FirstOrDefault(p => p.Id == id);

            if (payment == null) return NotFound();
            return Ok(payment);
        }


        [HttpPost]
        public IActionResult Create(Payment payment)
        {
            var payer = _context.Users.Find(payment.PayerId);
            var payee = _context.Users.Find(payment.PayeeId);

            if (payer == null || payee == null)
                return BadRequest("Payer or Payee not found.");

            if (payer.Balance < payment.Amount)
                return BadRequest("Insufficient balance.");

            payer.Balance -= payment.Amount;
            payee.Balance += payment.Amount;

            payment.Payer = null;
            payment.Payee = null;

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = payment.Id }, payment);
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment == null) return NotFound();

            _context.Payments.Remove(payment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
