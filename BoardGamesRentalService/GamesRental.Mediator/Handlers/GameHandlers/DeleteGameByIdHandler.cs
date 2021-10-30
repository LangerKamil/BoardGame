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
    public class DeleteGameByIdHandler : IRequestHandler<DeleteGameByIdCommand, bool>
    {
        IGameRepository _repository;
        public DeleteGameByIdHandler(IGameRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteGameByIdCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.Delete(request.id));
        }
    }
}
