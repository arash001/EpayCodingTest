using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAllCustomer();


        public void AddCustomer(Customer customer);


        public List<Customer> GetCustomers();
    
    }
}
