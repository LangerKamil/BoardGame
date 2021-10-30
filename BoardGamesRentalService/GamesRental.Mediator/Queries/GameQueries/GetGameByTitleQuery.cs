using GamesRental.Infrastructure.Models;
using MediatR;

namespace GamesRental.Mediator.Queries.GameQueries
{
    public record GetGameByTitleQuery(string title): IRequest<Game>;

}
