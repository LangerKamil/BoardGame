using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesRental.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        GamesStoreContext _dbContext;
        public CustomerRepository(GamesStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> Get()
        {
            return _dbContext.Customers.ToList();
        }


        public bool Insert(string firstName, string lastName, string email)
        {
            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email
            };

            _dbContext.Add(customer);
            _dbContext.SaveChanges();
            return true;
        }


        public bool Update(int id, string firstName, string lastName, string email)
        {
            var customerFromDb = _dbContext.Customers.Where(g => g.Id == id).FirstOrDefault();
            if (customerFromDb == null) throw new Exception("Customer couldn't be found");

            customerFromDb.FirstName = firstName;
            customerFromDb.LastName = lastName;
            customerFromDb.EmailAddress = email;

            _dbContext.SaveChanges();
            return true;
        }


        public bool Delete(int id)
        {

            var customerFromDb = _dbContext.Customers.Where(g => g.Id == id).FirstOrDefault();
            if (customerFromDb == null) throw new Exception("Game couldn't be found");

            _dbContext.Remove(customerFromDb);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
