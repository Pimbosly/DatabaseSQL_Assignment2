using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClientAssignment
{
    public class ConnectionConfig
    {
        public static string GetConnectionString()
        {
            return "Data Source=LAPTOP-DCVDOQFT\\SQLEXPRESS;Initial Catalog=Chinook;Integrated Security=True;TrustServerCertificate=True;";
        }

    }
}
