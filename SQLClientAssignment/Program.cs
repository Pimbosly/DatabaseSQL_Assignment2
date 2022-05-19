using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLClientAssignment
{
    public class Program
    {
        // Test data constants
        private const int TEST_ID = 2;

        private const string TEST_NAME = "Mi";

        private const int TEST_LIMIT = 10;
        private const int TEST_OFFSET = 0;

        private const string TEST_FIRSTNAME_CREATE = "Harry";
        private const string TEST_LASTNAME_CREATE = "Potter";
        private const string TEST_COUNTRY_CREATE = "England";
        private const string TEST_POSTALCODE_CREATE = "XXX";
        private const string TEST_PHONENUMBER_CREATE = "1234567";
        private const string TEST_EMAIL_CREATE = "harry@hogwarts.com";

        private const int TEST_ID_UPDATE = 2;
        private const string TEST_FIRSTNAME_UPDATE = "Ron";
        private const string TEST_LASTNAME_UPDATE = "Weasley";
        private const string TEST_COUNTRY_UPDATE = "England";
        private const string TEST_POSTALCODE_UPDATE = "XXX";
        private const string TEST_PHONENUMBER_UPDATE = "9876543";
        private const string TEST_EMAIL_UPDATE = "ron@hogwarts.com";


        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();

            // Read and display all customers
            TestGetAllCustomers(repository);

            // Read and display customer by id
            TestGetCustomerByID(repository);

            // Read and display customer(s) by (part of) name
            TestGetCustomerByName(repository);

            // Read and display page of customers, using limit and offset
            TestGetPageOfCustomers(repository);

            // Add new customer
            TestAddCustomer(repository);

            // Update customer
            TestUpdateCustomer(repository);

            // Get countries by frequency (highest - lowest)
            TestGetCountriesByFrequency(repository);

            // Get spenders by amount spent (highest - lowest)
            TestGetHighestSpenders(repository);

            // Get most popular genre for given customer
            TestGetMostPopularGenre(repository);

        }

        static void TestGetAllCustomers(ICustomerRepository repository)
        {
            List<Customer> allCustomers = new List<Customer>();
            
            allCustomers = repository.GetAllCustomers();
            foreach (Customer customer in allCustomers)
            {
                Display.DisplayCustomer(customer);
            }
            Console.WriteLine("Finished printing all customers\n");
        }

        static void TestGetCustomerByID(ICustomerRepository repository)
        {
            Customer selectedCustomer = new Customer();
            selectedCustomer = repository.GetCustomerById(TEST_ID);
            Display.DisplayCustomer(selectedCustomer);
        }

        static void TestGetCustomerByName(ICustomerRepository repository)
        {
            List<Customer> customersByName = new List<Customer>();
            customersByName = repository.GetCustomersByName(TEST_NAME);
            foreach (Customer customer in customersByName)
            {
                Display.DisplayCustomer(customer);
            }
        }

        static void TestGetPageOfCustomers(ICustomerRepository repository)
        {
            List<Customer> pageOfCustomers = new List<Customer>();
            pageOfCustomers = repository.GetPageOfCustomers(TEST_LIMIT, TEST_OFFSET);
            foreach (Customer customer in pageOfCustomers)
            {
                Display.DisplayCustomer(customer);
            }
        }

        static void TestAddCustomer(ICustomerRepository repository)
        {
            Customer newCustomer = new Customer();
            newCustomer.FirstName = TEST_FIRSTNAME_CREATE;
            newCustomer.LastName = TEST_LASTNAME_CREATE;
            newCustomer.Country = TEST_COUNTRY_CREATE;
            newCustomer.PostalCode = TEST_POSTALCODE_CREATE;
            newCustomer.PhoneNumber = TEST_PHONENUMBER_CREATE;
            newCustomer.Email = TEST_EMAIL_CREATE;
            repository.AddCustomer(newCustomer);
        }

        static void TestUpdateCustomer(ICustomerRepository repository)
        {
            Customer updateCustomer = new Customer();
            updateCustomer.Id = TEST_ID_UPDATE;
            updateCustomer.FirstName = TEST_FIRSTNAME_UPDATE;
            updateCustomer.LastName = TEST_LASTNAME_UPDATE;
            updateCustomer.Country = TEST_COUNTRY_UPDATE;
            updateCustomer.PostalCode = TEST_POSTALCODE_UPDATE;
            updateCustomer.PhoneNumber = TEST_PHONENUMBER_UPDATE;
            updateCustomer.Email = TEST_EMAIL_UPDATE;
            repository.UpdateCustomer(updateCustomer);
            Display.DisplayCustomer(updateCustomer);
        }

        static void TestGetCountriesByFrequency(ICustomerRepository repository)
        {
            List<CustomerCountry> countries = repository.GetCountriesByFrequency();
            Display.DisplayCountries(countries);
        }

        static void TestGetHighestSpenders(ICustomerRepository repository)
        {
            List<CustomerSpender> spenders = repository.GetHighestSpenders();
            Display.DisplaySpenders(spenders);
        }

        static void TestGetMostPopularGenre(ICustomerRepository repository)
        {
            Customer testCustomer = repository.GetCustomerById(TEST_ID);
            List<CustomerGenre> testGenres = repository.GetMostPopularGenre(testCustomer);
            foreach (CustomerGenre testGenre in testGenres)
            {
                Display.DisplayGenre(testGenre, testCustomer.FirstName, testCustomer.LastName);
            }
        }
    }
}