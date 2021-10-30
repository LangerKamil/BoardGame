using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Queries.GameQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.GameHandlers
{
    public class GetGameListByDescriptionHandler : IRequestHandler<GetGameListByDescriptionQuery, List<Game>>
    {
        IGameRepository _repository;
        public GetGameListByDescriptionHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Game>> Handle(GetGameListByDescriptionQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.GetByDescription(request.description));
        }
    }
}
