using MediatR;

namespace GamesRental.Mediator.Commands.GameCommands
{
    public record UpdateGameByIdCommand(int id,string title,string description,int amount,int price) : IRequest<bool>;

}
