using MediatR;

namespace GamesRental.Mediator.Commands.GameCommands
{
    public record DeleteGameByIdCommand(int id): IRequest<bool>;

}
