using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Commands.CustomerCommands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.CustomerHandlers
{
    public class UpdateExistingCustomerHandler : IRequestHandler<UpdateExistingCustomerCommand, bool>
    {
        ICustomerRepository _repository;
        public UpdateExistingCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateExistingCustomerCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.Update(request.id, request.firstName, request.lastName, request.email));
        }
    }
}
