using GamesRental.Infrastructure.Models;
using MediatR;
using System.Collections.Generic;

namespace GamesRental.Mediator.Queries.GameQueries
{
    public record GetGameListByDescriptionQuery(string description):IRequest<List<Game>>;

}
