using MediatR;

namespace GamesRental.Mediator.Commands.RentalCommands
{
    public record ReturnGameCommand(int gameId, string email) : IRequest<bool>;

}
