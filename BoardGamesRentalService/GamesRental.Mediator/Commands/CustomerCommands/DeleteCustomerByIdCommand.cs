using MediatR;

namespace GamesRental.Mediator.Commands.CustomerCommands
{
    public record DeleteCustomerByIdCommand(int id):IRequest<bool>;

}
