using MediatR;

namespace Carty.Customer.Commands
{
    public class UpdateCustomerCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
