using Microsoft.EntityFrameworkCore;

namespace Carty.Customer.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Models.Customer> GetCustomerAsync(string customerId)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == Guid.Parse(customerId));
        }

        public async Task<string> CreateCustomerAsync(Models.Customer customer)
        {
            customer.Id = Guid.NewGuid();
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.Id.ToString();
        }

        public async Task<string> UpdateCustomerAsync(Models.Customer customer)
        {
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == customer.Id);

            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                await _context.SaveChangesAsync();
            }
            return customer.Id.ToString();
        }
    }
}
