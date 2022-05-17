using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLClientAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Customer> ourCustomers = new List<Customer>();
            ICustomerRepository repository = new CustomerRepository();
            ourCustomers = repository.GetAllCustomers();
            foreach (Customer customer in ourCustomers)
            {
                Display.DisplayCustomer(customer);
            }
            Console.WriteLine("Finished printing all customers\n");
            Customer selectedCustomer = new Customer();
            selectedCustomer = repository.GetCustomerById(2);
            Display.DisplayCustomer(selectedCustomer);
        }
    }
}