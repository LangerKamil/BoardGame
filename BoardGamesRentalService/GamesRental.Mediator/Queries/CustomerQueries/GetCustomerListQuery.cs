using GamesRental.Infrastructure.Models;
using MediatR;
using System.Collections.Generic;

namespace GamesRental.Mediator.Queries.CustomerQueries
{
    public record GetCustomerListQuery: IRequest<List<Customer>>;

}
