using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Queries.RentalQueries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.RentalHandlers
{
    public class GetRentedGamesHandler : IRequestHandler<GetRentedGamesQuery, List<Game>>
    {
        IRentalRepository _repository;
        public GetRentedGamesHandler(IRentalRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Game>> Handle(GetRentedGamesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.GetRentedGames(request.email));
        }
    }

}
