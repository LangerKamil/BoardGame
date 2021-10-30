using MediatR;

namespace GamesRental.Mediator.Commands.CustomerCommands
{
    public record InsertNewCustomerCommand(string firstName,string lastName,string email):IRequest<bool>;

}
