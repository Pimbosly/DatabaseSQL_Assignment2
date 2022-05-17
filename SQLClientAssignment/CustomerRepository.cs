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
                    Customer customer = new Customer();

                    customer.Id = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = reader.GetString(2);
                    // For columns that are allowed to have null values, first check if value is null before using GetString method
                    if (!reader.IsDBNull(7)) customer.Country = reader.GetString(7); else customer.Country = null;
                    if (!reader.IsDBNull(8)) customer.PostalCode = reader.GetString(8); else customer.PostalCode = null;
                    if (!reader.IsDBNull(9)) customer.PhoneNumber = reader.GetString(9); else customer.PhoneNumber = null;
                    if (!reader.IsDBNull(11)) customer.Email = reader.GetString(11); else customer.Email = null;

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
                    // For columns that are allowed to have null values, first check if value is null before using GetString method
                    if (!reader.IsDBNull(7)) customer.Country = reader.GetString(7); else customer.Country = null;
                    if (!reader.IsDBNull(8)) customer.PostalCode = reader.GetString(8); else customer.PostalCode = null;
                    if (!reader.IsDBNull(9)) customer.PhoneNumber = reader.GetString(9); else customer.PhoneNumber = null;
                    if (!reader.IsDBNull(11)) customer.Email = reader.GetString(11); else customer.Email = null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customer;
        }

        public List<Customer> GetCustomersByName(string name)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                // Set up connetion
                using SqlConnection dbConnection = new SqlConnection(ConnectionConfig.GetConnectionString());

                // Open connection
                dbConnection.Open();

                // Prepare command
                string sql = "SELECT * FROM Customer WHERE LastName LIKE '%' + @customerLASTNAME + '%'"; 
                string customerLASTNAME = name;

                //Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                command.Parameters.AddWithValue("@customerLASTNAME", name);
                SqlDataReader reader = command.ExecuteReader();

                // Process results
                while (reader.Read())
                {
                    Customer customer = new Customer();

                    customer.Id = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = reader.GetString(2);
                    // For columns that are allowed to have null values, first check if value is null before using GetString method
                    if (!reader.IsDBNull(7)) customer.Country = reader.GetString(7); else customer.Country = null;
                    if (!reader.IsDBNull(8)) customer.PostalCode = reader.GetString(8); else customer.PostalCode = null;
                    if (!reader.IsDBNull(9)) customer.PhoneNumber = reader.GetString(9); else customer.PhoneNumber = null;
                    if (!reader.IsDBNull(11)) customer.Email = reader.GetString(11); else customer.Email = null;

                    customers.Add(customer);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers;
        }
    }
}
