using GamesRental.Infrastructure.Models;
using MediatR;
using System.Collections.Generic;

namespace GamesRental.Mediator.Queries.GameQueries
{
    public record GetGameListQuery : IRequest<List<Game>>;

}
