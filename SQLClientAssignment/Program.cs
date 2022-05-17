using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLClientAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Read and display all customers
            List<Customer> allCustomers = new List<Customer>();
            ICustomerRepository repository = new CustomerRepository();
            allCustomers = repository.GetAllCustomers();
            foreach (Customer customer in allCustomers)
            {
                Display.DisplayCustomer(customer);
            }
            Console.WriteLine("Finished printing all customers\n");

            // Read and display customer by id
            Customer selectedCustomer = new Customer();
            selectedCustomer = repository.GetCustomerById(2);
            Display.DisplayCustomer(selectedCustomer);

            // Read and display customer(s) by (part of) name
            List<Customer> customersByName = new List<Customer>();
            customersByName = repository.GetCustomersByName("Mi");
            foreach (Customer customer in customersByName)
            {
                Display.DisplayCustomer(customer);
            }

            // Read and display page of customers, using limit and offset
            List<Customer> pageOfCustomers = new List<Customer>();
            pageOfCustomers = repository.GetPageOfCustomers(10, 0);
            foreach (Customer customer in pageOfCustomers)
            {
                Display.DisplayCustomer(customer);
            }

            // Add new customer
            Customer newCustomer = new Customer();
            newCustomer.FirstName = "Harry";
            newCustomer.LastName = "Potter";
            newCustomer.Country = "England";
            newCustomer.PostalCode = "XXX";
            newCustomer.PhoneNumber = "1234567";
            newCustomer.Email = "harry@hogwarts.com";
            repository.AddCustomer(newCustomer);

            // Update customer
            repository.UpdateCustomer(1, CustomerField.Country, "Italy");
            Customer updatedCustomer = new Customer();
            updatedCustomer = repository.GetCustomerById(1);
            Display.DisplayCustomer(updatedCustomer);

        }
    }
}