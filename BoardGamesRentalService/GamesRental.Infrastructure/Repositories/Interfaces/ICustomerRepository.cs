using GamesRental.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRental.Infrastructure.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public List<Customer> Get();
        public bool Insert(string firstName, string lastName, string email);
        public bool Update(int id, string firstName, string lastName, string email);
        public bool Delete(int id);
    }
}
