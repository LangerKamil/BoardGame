using AutoMapper;
using GamesRental.Infrastructure.DTOs;
using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamesRental.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        GamesStoreContext _dbContext;
        IMapper _mapper;
        public GameRepository(GamesStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
         }

        public bool Delete(int id)
        {
            var gameFromDb = _dbContext.Games.Where(g => g.Id == id).FirstOrDefault();
            if (gameFromDb == null) throw new Exception("Game couldn't be found");

            _dbContext.Remove(gameFromDb);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Game> Get()
        {
            var gamesFromDb = _dbContext.Games.ToList();
            if (gamesFromDb == null) throw new Exception("There currently no games in the database");

            return _dbContext.Games.ToList();
        }

        public List<Game> GetByDescription(string description)
        {
            var gamesFromDb = _dbContext.Games.Where(g=>g.Description.Contains(description)).ToList();
            if (gamesFromDb == null) throw new Exception("There are no games with such a description");

            return gamesFromDb;
        }

        public List<Game> GetByName(string title)
        {
            var gamesFromDb = _dbContext.Games.Where(g => g.Title.Contains(title)).ToList();
            if (gamesFromDb == null) throw new Exception("There no games with this title");

            return gamesFromDb;
        }

        public Game GetSingleByName(string title)
        {
            var gameFromDb = _dbContext.Games.Where(g => g.Title.Contains(title)).FirstOrDefault();
            if (gameFromDb == null) throw new Exception("There no games with this title");

            return gameFromDb;
        }

        public bool Insert(string title, string description, int amount, int price)
        {
            GameDTO gameDTO = new GameDTO()
            {
                Title = title,
                Description = description,
                InStock = amount,
                Price = price
            };

            Game game = _mapper.Map<Game>(gameDTO);

            _dbContext.Add(game);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(int id, string title, string description, int amount, int price)
        {
            GameDTO gameDTO = new GameDTO()
            {
                Id = id,
                Title = title,
                Description = description,
                InStock = amount,
                Price = price
            };

            var gameFromDb = _dbContext.Games.Where(g => g.Id == id).FirstOrDefault();
            if (gameFromDb == null) throw new Exception("Game couldn't be found");

            _mapper.Map(gameFromDb, gameDTO);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
