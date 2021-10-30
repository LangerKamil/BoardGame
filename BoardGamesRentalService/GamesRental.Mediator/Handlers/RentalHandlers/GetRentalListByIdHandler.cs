using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Queries.RentalQueries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.RentalHandlers
{
    public class GetRentalListByIdHandler : IRequestHandler<GetRentalListByIdQuery, List<Rental>>
    {
        IRentalRepository _repository;
        public GetRentalListByIdHandler(IRentalRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Rental>> Handle(GetRentalListByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.Get(request.Id));
        }
    }
}
