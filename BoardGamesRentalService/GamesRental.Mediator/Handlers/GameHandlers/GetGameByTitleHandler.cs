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
    public class GetGameByTitleHandler: IRequestHandler<GetGameByTitleQuery, Game>
    {
        IGameRepository _repository;
        public GetGameByTitleHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<Game> Handle(GetGameByTitleQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.GetSingleByName(request.title));

        }
    }
}
