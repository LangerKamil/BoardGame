using MediatR;

namespace GamesRental.Mediator.Commands.RentalCommands
{
    public record RentGameCommand(int gameId, string firstName, string lastName, string email) :IRequest<bool>;
    

}
