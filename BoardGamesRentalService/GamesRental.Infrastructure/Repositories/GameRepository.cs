using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRental.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        GamesStoreContext _dbContext;
        public GameRepository(GamesStoreContext dbContext)
        {
            _dbContext = dbContext;
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
            Game game = new Game()
            {
                Title = title,
                Description = description,
                InStock = amount,
                Price = price
            };

            _dbContext.Add(game);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(int id, string title, string description, int amount, int price)
        {
            var gameFromDb = _dbContext.Games.Where(g => g.Id == id).FirstOrDefault();
            if (gameFromDb == null) throw new Exception("Game couldn't be found");

            gameFromDb.Title = title;
            gameFromDb.Description = description;
            gameFromDb.InStock = amount;
            gameFromDb.Price = price;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
