using GamesRental.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRental.Infrastructure.Repositories.Interfaces
{
    public interface IRentalRepository
    {
        public List<Rental> Get(int id);
        public List<Game> GetRentedGames(string email);
        public List<Rental> GetBlacklisted();
        public bool RentGame(int gameId, string firstName, string lastName, string email);
        public bool ReturnGame(int gameId, string email);
    }
}
