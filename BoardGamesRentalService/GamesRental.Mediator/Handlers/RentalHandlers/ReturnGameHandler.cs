using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Commands.RentalCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.RentalHandlers
{
    public class ReturnGameHandler : IRequestHandler<ReturnGameCommand, bool>
    {
        IRentalRepository _repository;
        public ReturnGameHandler(IRentalRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(ReturnGameCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.ReturnGame(request.gameId, request.email));
        }
    }
}
