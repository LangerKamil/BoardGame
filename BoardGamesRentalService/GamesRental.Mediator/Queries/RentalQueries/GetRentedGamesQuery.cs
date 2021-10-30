using GamesRental.Infrastructure.Models;
using MediatR;
using System.Collections.Generic;

namespace GamesRental.Mediator.Queries.RentalQueries
{
    public record GetRentedGamesQuery(string email) : IRequest<List<Game>>;

}
