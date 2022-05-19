using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientAssignment
{
    public class Display
    {
        /// <summary>
        /// Displays information about a customer in the console.
        /// </summary>
        /// <param name="customer">Customer object</param>
        public static void DisplayCustomer(Customer customer)
        {
            Console.WriteLine($"Id: {customer.Id}, First Name: {customer.FirstName}, Last Name: {customer.LastName}, Country: {customer.Country},\n" +
                $"Postal Code: {customer.PostalCode}, Phone Number: {customer.PhoneNumber}, Email: {customer.Email}\n");
        }

        /// <summary>
        /// Displays list of countries ordered by highest frequency in the console.
        /// </summary>
        /// <param name="countries">List of CustomerCountry objects</param>
        public static void DisplayCountries(List<CustomerCountry> countries)
        {
            Console.WriteLine("\nCountries by highest frequency:");
            foreach (CustomerCountry country in countries)
            {
                Console.WriteLine($"Country: {country.CountryName}, frequency: {country.Amount}");
            }
        }

        /// <summary>
        /// Displays list of spenders ordered by highest amount in the console.
        /// </summary>
        /// <param name="spenders">List of CustomerSpender objects</param>
        public static void DisplaySpenders(List<CustomerSpender> spenders)
        {
            Console.WriteLine("\nSpenders by highest amount:");
            foreach (CustomerSpender spender in spenders)
            {
                Console.WriteLine($"Customer {spender.Id} {spender.FirstName} {spender.LastName}, amount spent: {spender.Amount}");
            }
        }

        /// <summary>
        /// Displays one or more popular genres of customer in the console.
        /// </summary>
        /// <param name="genre">CustomerGenre object</param>
        /// <param name="firstName">String representing first name of customer</param>
        /// <param name="lastName">String representing first name of customer</param>
        public static void DisplayGenre(CustomerGenre genre, string firstName, string lastName)
        {
            Console.WriteLine($"Customer {firstName} {lastName}'s most popular music genre is {genre.GenreName}. They bought {genre.TrackAmount} tracks.");
        }
    }
}
