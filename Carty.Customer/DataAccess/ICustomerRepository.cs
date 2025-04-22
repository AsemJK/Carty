namespace Carty.Customer.DataAccess
{
    public interface ICustomerRepository
    {
        Task<Models.Customer> GetCustomerAsync(string customerId);
        Task<string> CreateCustomerAsync(Models.Customer customer);
        Task<string> UpdateCustomerAsync(Models.Customer customer);
    }
}
