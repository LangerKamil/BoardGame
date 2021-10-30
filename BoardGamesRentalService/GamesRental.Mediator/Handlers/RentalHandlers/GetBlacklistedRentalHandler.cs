using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Queries.RentalQueries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.RentalHandlers
{
    public class GetBlacklistedRentalHandler : IRequestHandler<GetBlacklistedRentalQuery, List<Rental>>
    {
        IRentalRepository _repository;
        public GetBlacklistedRentalHandler(IRentalRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Rental>> Handle(GetBlacklistedRentalQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.GetBlacklisted());
        }
    }
}
