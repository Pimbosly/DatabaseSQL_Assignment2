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
                Console.WriteLine($"Customer with id {customer.Id}, first name {customer.FirstName} and last name {customer.LastName}");
            }
            Console.WriteLine("finished");
            Customer selectedCustomer = new Customer();
            selectedCustomer = repository.GetCustomerById(2);
            Console.WriteLine($"Customer with id {selectedCustomer.Id}, first name {selectedCustomer.FirstName} and last name {selectedCustomer.LastName}, lives in {selectedCustomer.Country}");
        }
    }
}