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
    public class UpdateGameByIdHandler : IRequestHandler<UpdateGameByIdCommand, bool>
    {
        IGameRepository _repository;
        public UpdateGameByIdHandler(IGameRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateGameByIdCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.Update(request.id, request.title, request.description, request.amount, request.price));
        }
    }
}
