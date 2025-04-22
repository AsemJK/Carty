using Carty.Customer.Commands;
using Carty.Customer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carty.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(string customerId)
        {
            var query = new GetCustomerQuery { CustomerId = customerId };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateCustomer(CreateCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCustomer), new { customerId }, customerId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(string id, UpdateCustomerCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return NoContent();
        }

    }
}
