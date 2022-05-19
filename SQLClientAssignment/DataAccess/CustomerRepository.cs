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
        /// <summary>
        /// Gets all customers from database
        /// </summary>
        /// <returns>List of customers</returns>
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
                    ReadCustomerFields(customer, reader);
                    customers.Add(customer);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers;
        }

        /// <summary>
        /// Gets customer by id
        /// </summary>
        /// <param name="id">integer representing customer id</param>
        /// <returns>customer object</returns>
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
                
                // Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                command.Parameters.AddWithValue("@customerID", id);
                SqlDataReader reader = command.ExecuteReader();

                // Process results
                while (reader.Read())
                {
                    ReadCustomerFields(customer, reader);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customer;
        }

        /// <summary>
        /// Gets customer by last name.
        /// </summary>
        /// <param name="name">string representing full name or part of name</param>
        /// <returns>List of customers with lastname matching name parameter</returns>
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

                // Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                command.Parameters.AddWithValue("@customerLASTNAME", name);
                SqlDataReader reader = command.ExecuteReader();

                // Process results
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    ReadCustomerFields(customer, reader);
                    customers.Add(customer);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers;
        }

        /// <summary>
        /// Gets list of customers, starting at an offset and setting a limit amount.
        /// </summary>
        /// <param name="limit">Integer representing the number of customers that should be displayed.</param>
        /// <param name="offset">Integer representing the start point of customers that should be displayed.</param>
        /// <returns>List of customer objects</returns>
        public List<Customer> GetPageOfCustomers(int limit, int offset)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                // Set up connetion
                using SqlConnection dbConnection = new SqlConnection(ConnectionConfig.GetConnectionString());

                // Open connection
                dbConnection.Open();

                // Prepare command
                string sql = "SELECT * FROM Customer ORDER BY CustomerId OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";

                // Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                command.Parameters.AddWithValue("@limit", limit);
                command.Parameters.AddWithValue("@offset", offset);
                SqlDataReader reader = command.ExecuteReader();

                // Process results
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    ReadCustomerFields(customer, reader);
                    customers.Add(customer);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers;
        }

        /// <summary>
        /// Adds new customer to the database.
        /// </summary>
        /// <param name="customer">Customer object with values of the new customer</param>
        public void AddCustomer(Customer customer)
        {
            try
            {
                // Set up connetion
                using SqlConnection dbConnection = new SqlConnection(ConnectionConfig.GetConnectionString());

                // Open connection
                dbConnection.Open();

                // Prepare command
                string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, @PostalCode, @PhoneNumber, @Email)";

                // Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.ExecuteNonQuery();

                // Print confirmation
                Console.WriteLine($"Added customer {customer.FirstName} {customer.LastName} to database.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing customer in the database.
        /// </summary>
        /// <param name="customer">Customer object</param>
        public void UpdateCustomer(Customer customer)
        {
            try
            {
                // Set up connetion
                using SqlConnection dbConnection = new SqlConnection(ConnectionConfig.GetConnectionString());

                // Open connection
                dbConnection.Open();

                // Prepare command
                string sql = "UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, Country=@Country, " + 
                    "PostalCode=@PostalCode, Phone=@Phone, Email=@Email WHERE CustomerId=@CustomerID";

                // Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                command.Parameters.AddWithValue("@CustomerID", customer.Id);
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                command.Parameters.AddWithValue("@Phone", customer.PhoneNumber);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.ExecuteNonQuery();

                // Print confirmation
                Console.WriteLine($"Updated customer with id {customer.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Helper function to read and store customer values for Id, FirstName, LastName, Country, PostalCode, Phone and Email.
        /// </summary>
        /// <param name="customer">Customer object</param>
        /// <param name="reader">SqlDataReader object</param>
        private void ReadCustomerFields(Customer customer, SqlDataReader reader)
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

        /// <summary>
        /// Gets countries ordered by number of customers that live in the country, sorted from highest to lowest.
        /// </summary>
        /// <returns>List of CustomerCountry objects</returns>
        public List<CustomerCountry> GetCountriesByFrequency()
        {
            List<CustomerCountry> countries = new List<CustomerCountry>();
            try
            {
                // Set up connetion
                using SqlConnection dbConnection = new SqlConnection(ConnectionConfig.GetConnectionString());

                // Open connection
                dbConnection.Open();

                // Prepare command
                string sql = "SELECT Country, COUNT(CustomerId) FROM Customer " +
                               "GROUP BY Country ORDER BY COUNT(CustomerId) DESC";

                //Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                SqlDataReader reader = command.ExecuteReader();

                // Process results
                while (reader.Read())
                {
                    CustomerCountry country = new CustomerCountry();
                    country.CountryName = reader.GetString(0);
                    country.Amount = reader.GetInt32(1);
                    countries.Add(country);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return countries;
        }

        /// <summary>
        /// Gets customers who are the highest spenders in descending order.
        /// </summary>
        /// <returns>List of CustomerSpender objects</returns>
        public List<CustomerSpender> GetHighestSpenders()
        {
            List<CustomerSpender> spenders = new List<CustomerSpender>();
            try
            {
                // Set up connetion
                using SqlConnection dbConnection = new SqlConnection(ConnectionConfig.GetConnectionString());

                // Open connection
                dbConnection.Open();

                // Prepare command
                string sql = "SELECT SUM(i.Total), i.CustomerId, c.FirstName, c.LastName FROM Invoice i, Customer c " +
                            "WHERE i.CustomerId = c.CustomerId " +
                            "GROUP BY i.CustomerId, c.FirstName, c.LastName " +
                            "ORDER BY SUM(i.Total) DESC";

                //Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                SqlDataReader reader = command.ExecuteReader();

                // Process results
                while (reader.Read())
                {
                    CustomerSpender spender = new CustomerSpender();
                    spender.Amount = Convert.ToDouble(reader.GetDecimal(0));
                    spender.Id = reader.GetInt32(1);
                    spender.FirstName = reader.GetString(2);
                    spender.LastName = reader.GetString(3);
                    spenders.Add(spender);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return spenders;

        }

        /// <summary>
        /// Gets most popular genre of a given customer, based on number of corresponding tracks in invoices. Returns multiple genres in case of a tie.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>List of CustomerGenre objects</returns>
        public List<CustomerGenre> GetMostPopularGenre(Customer customer)
        {
            List<CustomerGenre> genres = new List<CustomerGenre>();
            try
            {
                // Set up connetion
                using SqlConnection dbConnection = new SqlConnection(ConnectionConfig.GetConnectionString());

                // Open connection
                dbConnection.Open();

                // Prepare command
                string sql = "SELECT TOP 1 WITH TIES g.Name, COUNT(g.GenreId) FROM Invoice i, InvoiceLine il, Track t, Genre g " +
                                "WHERE i.InvoiceId=il.InvoiceId AND il.TrackId=t.TrackId AND t.GenreId=g.GenreId AND i.CustomerId=@CustomerID " +
                                "GROUP BY g.Name ORDER BY COUNT(g.GenreId) DESC";

                // Execute command
                SqlCommand command = new SqlCommand(sql, dbConnection);
                command.Parameters.AddWithValue("@customerID", customer.Id);
                SqlDataReader reader = command.ExecuteReader();

                // Process results
                while (reader.Read())
                {
                    CustomerGenre genre = new CustomerGenre();
                    genre.GenreName = reader.GetString(0);
                    genre.TrackAmount = reader.GetInt32(1);
                    genres.Add(genre);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return genres;
        }
    }
}
