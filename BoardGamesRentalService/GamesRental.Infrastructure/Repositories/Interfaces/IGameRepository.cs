using GamesRental.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRental.Infrastructure.Repositories.Interfaces
{
    public interface IGameRepository
    {
        public List<Game> Get();
        public bool Insert(string title, string description, int amount, int price);
        public bool Update(int id, string title, string description, int amount, int price);
        public bool Delete(int id);
        public List<Game> GetByName(string title);
        public List<Game> GetByDescription(string description);
        public Game GetSingleByName(string title);

    }
}
