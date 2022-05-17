using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientAssignment
{
    public class Display
    {
        public static void DisplayCustomer(Customer customer)
        {
            Console.WriteLine($"Id: {customer.Id}, First Name: {customer.FirstName}, Last Name: {customer.LastName}, Country: {customer.Country},\n" +
                $"Postal Code: {customer.PostalCode}, Phone Number: {customer.PhoneNumber}, Email: {customer.Email}\n");
        }
    }
}
