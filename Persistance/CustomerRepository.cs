using Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly RepositoryDbContext _dbContext;
        ICustomerRepository _customerRepository;

        public CustomerRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> GetAllCustomer()
        {
            return _dbContext.Customers.ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _dbContext.Set<Customer>().Add(customer);
            _dbContext.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            return _dbContext.Set<Customer>().ToList();
        }
    }
}
