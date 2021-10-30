using MediatR;

namespace GamesRental.Mediator.Commands.CustomerCommands
{
    public record UpdateExistingCustomerCommand(int id,string firstName,string lastName,string email):IRequest<bool>;
 
}
