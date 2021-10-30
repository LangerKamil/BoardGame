using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Commands.CustomerCommands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.CustomerHandlers
{
    public class InsertNewCustomerHandler : IRequestHandler<InsertNewCustomerCommand, bool>
    {
        ICustomerRepository _repository;
        public InsertNewCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(InsertNewCustomerCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.Insert(request.firstName, request.lastName, request.email));
        }
    }
}
