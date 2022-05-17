using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientAssignment
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        List<Customer> GetCustomersByName(string name);
    }
}
