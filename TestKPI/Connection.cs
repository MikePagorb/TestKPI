using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestKPI
{
    class Connection
    {
        private static SqlConnection instance;
        public string connectionString { get; private set; }
        protected Connection(string constr = @"Data Source=LAPTOP-E1KKJ6T9\SQLEXPRESS;Initial Catalog=Conferences;Integrated Security=True")
        {
            this.connectionString = constr;
        }
        public static SqlConnection getInstance(string constr = @"Data Source=LAPTOP-E1KKJ6T9\SQLEXPRESS;Initial Catalog=Conferences;Integrated Security=True")
        {
            if (instance == null)
                instance = new SqlConnection(constr);
            return instance;
        }
    }

    class ConnectionToDB
    {
        public SqlConnection ConnectionDB { get; private set; }
        public void SetConnection()
        {
            ConnectionDB = Connection.getInstance();
        }
    }
}
