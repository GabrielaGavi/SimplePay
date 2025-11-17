using Microsoft.EntityFrameworkCore;
using SimplePay.Models;
using System.Collections.Generic;

namespace SimplePay.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
