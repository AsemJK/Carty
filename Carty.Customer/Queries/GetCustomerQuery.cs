using MediatR;

namespace Carty.Customer.Queries
{
    public class GetCustomerQuery : IRequest<CustomerDto>
    {
        public string CustomerId { get; set; }
    }
    public class CustomerDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
