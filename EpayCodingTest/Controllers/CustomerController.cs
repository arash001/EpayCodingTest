using Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistance;

namespace EpayCodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private RepositoryDbContext _dbContext;
        private ICustomerRepository _customerRepository;

        public CustomerController(RepositoryDbContext repositoryDbContext,ICustomerRepository customerRepository)
       

            {
                _dbContext = repositoryDbContext;
            _customerRepository = new CustomerRepository(_dbContext);

            }


     

        [HttpGet]
        [Route("customers")]
        public ActionResult GetCustomers()
        {

            return Ok(this._customerRepository.GetAllCustomer());
        }
        [HttpPost]
        [Route("customers")]
        public ActionResult PostCustomers(List<Customer> newCustomers)
        {
            var customers = this._customerRepository.GetAllCustomer();
            // Validate each customer in the request
            foreach (var customer in newCustomers)
            {
                if (string.IsNullOrEmpty(customer.FirstName) ||
                    string.IsNullOrEmpty(customer.LastName) ||
                    customer.Age <= 18 ||
                    customers.Any(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName && c.Age == customer.Age))
                {
                    return BadRequest("Invalid customer data.");
                }
            }

            InsertIntoDb(newCustomers, customers);

            return Ok();
        }

        private void InsertIntoDb(List<Customer> newCustomers, List<Customer> customers)
        {
            // Insert customers into the sorted position in the array
            foreach (var customer in newCustomers)
            {
                int insertIndex = customers.FindLastIndex(c =>
                    string.Compare(c.LastName, customer.LastName, StringComparison.Ordinal) > 0 ||
                    (string.Compare(c.LastName, customer.LastName, StringComparison.Ordinal) == 0 &&
                     string.Compare(c.FirstName, customer.FirstName, StringComparison.Ordinal) > 0));

                if (insertIndex == -1)
                {
                    customers.Insert(0, customer);
                    _customerRepository.AddCustomer(customer);
                }
                else
                {
                    customers.Insert(insertIndex + 1, customer);
                }
            }
        }
    }
}
