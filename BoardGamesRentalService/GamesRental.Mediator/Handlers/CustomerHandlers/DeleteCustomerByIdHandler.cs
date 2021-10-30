using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Commands.CustomerCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.CustomerHandlers
{
    public class DeleteCustomerByIdHandler : IRequestHandler<DeleteCustomerByIdCommand, bool>
    {
        ICustomerRepository _repository;
        public DeleteCustomerByIdHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.Delete(request.id));
        }
    }
}
