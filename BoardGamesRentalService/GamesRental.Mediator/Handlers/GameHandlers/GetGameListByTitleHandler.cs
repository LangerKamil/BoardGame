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
    public class GetGameListByTitleHandler : IRequestHandler<GetGameListByTitleQuery, List<Game>>
    {
        IGameRepository _repository;
        public GetGameListByTitleHandler(IGameRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Game>> Handle(GetGameListByTitleQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.GetByName(request.title));
        }
    }
}
