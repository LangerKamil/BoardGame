using GamesRental.Infrastructure.Models;
using GamesRental.Mediator.Commands.RentalCommands;
using GamesRental.Mediator.Queries.RentalQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardGamesRentalService.Controllers
{

    public class RentalController : ControllerBase
    {
        IMediator _mediator;
        public RentalController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("rental/get/{id}")]
        public async Task<List<Rental>> Get(int id)
        {
            return await _mediator.Send(new GetRentalListByIdQuery(id));
        }

        [HttpGet]
        [Route("rental/get/rentedGames/{email}")]
        public async Task<List<Game>> GetRentedGames(string email)
        {
            return await _mediator.Send(new GetRentedGamesQuery(email));
        }

        [HttpGet]
        [Route("rental/get/blacklisted")]
        public async Task<List<Rental>> GetBlacklisted()
        {
            return await _mediator.Send(new GetBlacklistedRentalQuery());

            
        }

        [HttpPost]
        [Route("rental/add/{gameId}/{firstName}/{lastName}/{email}")]
        public async Task<bool> RentGame(int gameId, string firstName, string lastName, string email)
        {
            return await _mediator.Send(new RentGameCommand(gameId, firstName, lastName, email));
        }

        [HttpPost]
        [Route("rental/return/{gameId}/{email}")]
        public async Task<bool> ReturnGame(int gameId, string email)
        {
            return await _mediator.Send(new ReturnGameCommand(gameId, email));
        }
    }
}
