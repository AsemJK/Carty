using Carty.Customer.DataAccess;
using MediatR;

namespace Carty.Customer.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, string>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Carty.Customer.Models.Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            // Create the customer and get the generated ID
            var customerId = await _customerRepository.CreateCustomerAsync(customer);
            return customerId;
        }
    }
}
