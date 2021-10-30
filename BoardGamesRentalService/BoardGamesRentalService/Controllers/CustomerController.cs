using GamesRental.Infrastructure.Models;
using GamesRental.Mediator.Commands.CustomerCommands;
using GamesRental.Mediator.Queries.CustomerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardGamesRentalService.Controllers
{
    public class CustomerController : ControllerBase
    {
        IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("customer/get")]
        public async Task<List<Customer>> Get()
        {
            return await _mediator.Send(new GetCustomerListQuery());
        }

        [HttpPost]
        [Route("customer/add/{firstName}/{lastName}/{email}")]
        public async Task<bool> Insert(string firstName, string lastName, string email)
        {

            return await _mediator.Send(new InsertNewCustomerCommand(firstName, lastName, email));
        }

        [HttpPut]
        [Route("customer/edit/{id}/{firstName}/{lastName}/{email}")]
        public async Task<bool> Update(int id, string firstName, string lastName, string email)
        {
            return await _mediator.Send(new UpdateExistingCustomerCommand(id, firstName, lastName, email));
        }

        [HttpDelete]
        [Route("customer/delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _mediator.Send(new DeleteCustomerByIdCommand(id));
        }
    } 
}
