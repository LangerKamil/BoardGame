using GamesRental.Infrastructure.Models;
using MediatR;
using System.Collections.Generic;

namespace GamesRental.Mediator.Queries.RentalQueries
{
    public record GetBlacklistedRentalQuery: IRequest<List<Rental>>;

}
