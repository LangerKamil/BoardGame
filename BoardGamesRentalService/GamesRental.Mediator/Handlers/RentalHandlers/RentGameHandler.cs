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
    public class RentGameHandler : IRequestHandler<RentGameCommand, bool>
    {
        IRentalRepository _repository;
        public RentGameHandler(IRentalRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(RentGameCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.RentGame(request.gameId, request.firstName, request.lastName, request.email));
        }
    }
}
