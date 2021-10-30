using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Commands.GameCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.GameHandlers
{
    public class InsertNewGameHandler : IRequestHandler<InsertNewGameCommand, bool>
    {
        IGameRepository _repository;
        public InsertNewGameHandler(IGameRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(InsertNewGameCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.Insert(request.title, request.description, request.amount, request.price));
        }
    }
}
