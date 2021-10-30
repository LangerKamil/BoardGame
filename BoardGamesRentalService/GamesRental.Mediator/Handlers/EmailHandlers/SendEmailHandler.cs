using GamesRental.Infrastructure.Repositories.Interfaces;
using GamesRental.Mediator.Commands.EmailCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesRental.Mediator.Handlers.EmailHandlers
{
    public record SendEmailHandler : IRequestHandler<SendEmailCommand, bool>
    {
        IEmailRepository _repository;
        public SendEmailHandler(IEmailRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_repository.SendEmail(request.addresses));
        }
    }
}
