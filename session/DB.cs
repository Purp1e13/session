using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session
{
    internal class DB
    {
        MySqlConnection dbconection = new MySqlConnection("server = 127.0.0.1;port = 3306;username=root;password=1234;database=test");

        public void openConnection()
        {
            if(dbconection.State == System.Data.ConnectionState.Closed)
                dbconection.Open();
        }
        public void closeConnection()
        {
            if(dbconection.State == System.Data.ConnectionState.Open)
                dbconection.Close();
        }
        public MySqlConnection GetConnection()
        {
            return dbconection;
        }
    }
}
