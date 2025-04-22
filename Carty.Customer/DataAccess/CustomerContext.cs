using Microsoft.EntityFrameworkCore;

namespace Carty.Customer.DataAccess
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options) { }
        public DbSet<Models.Customer> Customers { get; set; }
    }
}
