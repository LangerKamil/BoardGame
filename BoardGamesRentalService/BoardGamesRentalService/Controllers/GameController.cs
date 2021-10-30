using GamesRental.Infrastructure.Models;
using GamesRental.Mediator.Commands.GameCommands;
using GamesRental.Mediator.Queries.GameQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoardGamesRentalService.Controllers
{
    public class GameController : Controller
    {
        IMediator _mediator;
        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("game/get")]
        public async Task<List<Game>> Get()
        {
            return await _mediator.Send(new GetGameListQuery());
        }



        [HttpGet]
        [Route("game/get/byTitle/{title}")]
        public async Task<List<Game>> GetGamesByTitle(string title)
        {
            return await _mediator.Send(new GetGameListByTitleQuery(title));
        }

        [HttpGet]
        [Route("game/get/singleByTitle/{title}")]
        public async Task<List<Game>> GetGameByTitle(string title)
        {
            return await _mediator.Send(new GetGameListByTitleQuery(title));
        }

        [HttpGet]
        [Route("game/get/byDescription/{description}")]
        public async Task<List<Game>> GetGameByDescription(string description)
        {
            return await _mediator.Send(new GetGameListByDescriptionQuery(description));
        }


        [HttpPost]
        [Route("game/add/{title}/{description}/{amount}/{price}")]
        public async Task<bool> Insert(string title,string description, int amount,int price )
        {
            return await _mediator.Send(new InsertNewGameCommand(title,description,amount,price));
        }

        [HttpPut]
        [Route("game/edit/{id}/{title}/{description}/{amount}/{price}")]
        public async Task<bool> Update(int id,string title, string description, int amount, int price)
        {
            return await _mediator.Send(new UpdateGameByIdCommand(id,title,description,amount,price));
        }

        [HttpDelete]
        [Route("game/delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _mediator.Send(new DeleteGameByIdCommand(id));
        }

    }
}
