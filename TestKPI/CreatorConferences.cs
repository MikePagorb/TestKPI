using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TestKPI
{
    class CreatorConferences
    {
        public void CreateConferencesNextYear(SqlConnection connection)
        {
            String sqlCommand = @"Select con.NameOfConf, con.Topic, Year(t.TermOfCarryingOut) as 'year', 
                MONTH(t.TermOfCarryingOut) as 'month', DAY(t.TermOfCarryingOut) as 'day' from Conferences con 
                Left join Terms t on con.ConfId = t.ConfId";

            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("Organization of Conferences on 2021: ");
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));
                Console.WriteLine();
                int year = 0;
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader.GetValue(2)) < 2020)
                    {
                        year = 1 + Convert.ToInt32(reader.GetValue(2)) + (2020 - Convert.ToInt32(reader.GetValue(2)));
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetValue(0), reader.GetValue(1), year, reader.GetValue(3), reader.GetValue(4));
                    }
                    else if(Convert.ToInt32(reader.GetValue(2)) == 2020)
                    {
                        year = 1 + Convert.ToInt32(reader.GetValue(2));
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetValue(0), reader.GetValue(1), year, reader.GetValue(3), reader.GetValue(4));
                    }
                    else
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4));
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
