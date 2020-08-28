using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TestKPI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionToDB connect = new ConnectionToDB();
            connect.SetConnection();
            try
            {
                connect.ConnectionDB.Open();
                Console.WriteLine("Connection open");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connect.ConnectionDB.Close();
                Console.WriteLine("Connection close");
            }
        }
    }
}
