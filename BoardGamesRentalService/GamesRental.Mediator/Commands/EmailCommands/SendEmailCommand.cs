using MediatR;

namespace GamesRental.Mediator.Commands.EmailCommands
{
    public record SendEmailCommand(string addresses) :IRequest<bool>;

}
