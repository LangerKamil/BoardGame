using GamesRental.Infrastructure.Models;
using GamesRental.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace GamesRental.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        GamesStoreContext _dbContext;
        IMapper _mapper;

        public CustomerRepository(GamesStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<Customer> Get()
        {
            return _dbContext.Customers.ToList();
        }


        public bool Insert(string firstName, string lastName, string email)
        {
            CustomerDTO customerDTO = new CustomerDTO()
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email
            };

            Customer customer = _mapper.Map<Customer>(customerDTO);

            _dbContext.Add(customer);
            _dbContext.SaveChanges();
            return true;
        }


        public bool Update(int id, string firstName, string lastName, string email)
        {            
            CustomerDTO customerDTO = new CustomerDTO 
            {  
                Id = id, 
                FirstName = firstName, 
                LastName = lastName, 
                EmailAddress = email 
            };

            var customerFromDb = _dbContext.Customers.Where(g => g.Id == id).FirstOrDefault();
            if (customerFromDb == null) throw new Exception("Customer couldn't be found");

            _mapper.Map(customerDTO, customerFromDb);
            _dbContext.SaveChanges();
            return true;
        }


        public bool Delete(int id)
        {

            var customerFromDb = _dbContext.Customers.Where(g => g.Id == id).FirstOrDefault();
            if (customerFromDb == null) throw new Exception("Customer couldn't be found");

            _dbContext.Remove(customerFromDb);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
