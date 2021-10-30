using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamesRental.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        GamesStoreContext _dbContext;
        ICustomerRepository _customerRepository;
        public RentalRepository(GamesStoreContext dbContext,ICustomerRepository customerRepository)
        {
            _dbContext = dbContext;
            _customerRepository = customerRepository;
        }
        public List<Rental> Get(int id)
        {
            return _dbContext.Rentals.Include(c => c.Customer).Where(c => c.CustomerId == id).Include(g => g.Game).Include(r => r.RentalStatus).ToList();

        }

        public List<Rental> GetBlacklisted()
        {
            int maxRentalTime = 2;
            var query = _dbContext.Rentals.Include(c => c.Customer).Include(g => g.Game).ToList();
            var rents = query.Where(c => c.Difference.Minutes > maxRentalTime).Where(c=>c.RentalStatusId==1).ToList();

            return rents;
        }

        public List<Game> GetRentedGames(string email)
        {
            var customerFromDb = _dbContext.Customers.Where(c => c.EmailAddress == email).FirstOrDefault();
            if (customerFromDb == null) throw new Exception("There is no user with provided email address");

            var gamesFromDb = from games in _dbContext.Games
                              join rentals in _dbContext.Rentals on games.Id equals rentals.GameId
                              where rentals.CustomerId == customerFromDb.Id
                              where rentals.RentalStatusId == 1
                              select games;

            var userGames = gamesFromDb.ToList();



            return userGames;
        }

        public bool RentGame(int gameId, string firstName, string lastName, string email)
        {
            var customerFromDb = _dbContext.Customers.Where(c => c.FirstName == firstName && c.LastName == lastName && c.EmailAddress == email).FirstOrDefault();
            if (customerFromDb == null)

                _customerRepository.Insert(firstName, lastName, email);

            var returnDate = DateTime.Now;
            var customer = _dbContext.Customers.Where(c => c.EmailAddress == email).FirstOrDefault();
            var gameFromDb = _dbContext.Games.Where(g => g.Id == gameId).FirstOrDefault();

            gameFromDb.InStock -= 1;

            Rental rental = new Rental()
            {
                CustomerId = customer.Id,
                GameId = gameId,
                RentalDate = DateTime.Now,
                RentalStatusId = 1,
                ReturnDate = returnDate
            };

            _dbContext.Rentals.Add(rental);
            _dbContext.SaveChanges();

            return true;
        }

        public bool ReturnGame(int gameId, string email)
        {
            var rentalsFromDb = from rentals in _dbContext.Rentals
                                join customers in _dbContext.Customers on rentals.CustomerId equals customers.Id
                                where customers.EmailAddress == email
                                join games in _dbContext.Games on rentals.GameId equals gameId
                                select rentals;

            rentalsFromDb.FirstOrDefault().RentalStatusId = 2;
            rentalsFromDb.FirstOrDefault().ReturnDate = DateTime.Now;

            var gamefromDb = _dbContext.Games.Where(g=>g.Id==gameId).FirstOrDefault();

            gamefromDb.InStock += 1;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
