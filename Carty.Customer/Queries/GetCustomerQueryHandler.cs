using Carty.Customer.DataAccess;
using MediatR;
namespace Carty.Customer.Queries
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }
        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerAsync(request.CustomerId);
            if (customer == null)
            {
                return null;
            }

            return new CustomerDto
            {
                Id = customer.Id.ToString(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }
    }
}
