using GamesRental.Mediator.Commands.EmailCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoardGamesRentalService.Controllers
{

    public class EmailController : ControllerBase
    {
        IMediator _mediator;
        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("email/send/{addresses}")]
        public async Task<bool> SendEmail(string addresses)
        {
            return await _mediator.Send(new SendEmailCommand(addresses));
        }
    }
}
