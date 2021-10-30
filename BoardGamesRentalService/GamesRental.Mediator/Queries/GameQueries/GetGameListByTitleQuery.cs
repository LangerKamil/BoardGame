using GamesRental.Infrastructure.Models;
using MediatR;
using System.Collections.Generic;

namespace GamesRental.Mediator.Queries.GameQueries
{
    public record GetGameListByTitleQuery(string title):IRequest<List<Game>>;
    
}
