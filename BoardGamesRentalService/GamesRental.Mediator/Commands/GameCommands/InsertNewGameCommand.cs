using MediatR;

namespace GamesRental.Mediator.Commands.GameCommands
{
    public record InsertNewGameCommand(string title,string description, int amount, int price): IRequest<bool>;

}
