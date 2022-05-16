using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientAssignment
{
    public class CustomerRepository : ICustomerRepository
    {

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                // Set up connetion
                using SqlConnection dbConnection = new SqlConnection(ConnectionConfig.GetConnectionString());

                // Open connection
                dbConnection.Open();

                // Prepare command
                string sql = "SELECT * FROM Customer";

                //Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                SqlDataReader reader = command.ExecuteReader();

                // Process results
                while (reader.Read())
                {
                    Customer customer = new Customer()
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    };
                    customers.Add(customer);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();
            try
            {
                // Set up connetion
                using SqlConnection dbConnection = new SqlConnection(ConnectionConfig.GetConnectionString());

                // Open connection
                dbConnection.Open();

                // Prepare command
                string sql = "SELECT * FROM Customer WHERE CustomerId=@customerID";
                int customerID = id;

                //Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                command.Parameters.AddWithValue("@customerID", id);
                SqlDataReader reader = command.ExecuteReader();

                // Process results
                while (reader.Read())
                {
                    customer.Id = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = reader.GetString(2);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customer;

        }
    }
}
