using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace CargoManagementSystem
{
    public class Database
    {
        public void db() 
        {
            string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
        }
    }
}
