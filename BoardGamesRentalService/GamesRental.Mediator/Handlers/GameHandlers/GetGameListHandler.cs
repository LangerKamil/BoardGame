using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Queries.GameQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.GameHandlers
{
    public class GetGameListHandler : IRequestHandler<GetGameListQuery, List<Game>>
    {
        private readonly IGameRepository _repository;
        public GetGameListHandler(IGameRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Game>> Handle(GetGameListQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.Get());
        }
    }
}
