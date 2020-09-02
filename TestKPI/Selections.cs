using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TestKPI
{
    class Selections
    {
        public void TakeConferencesNextKvartal(SqlConnection connection)
        {
            String sqlCommand = @"Select con.NameOfConf, con.Topic, t.TermOfCarryingOut, c.Cost from Conferences con 
                                Left join Terms t on con.ConfId = t.ConfId Left Join ConfCost c on con.ConfId = c.ConfId 
                                where Month(t.TermOfCarryingOut)= 9
                                or Month(t.TermOfCarryingOut)= 10
                                or Month(t.TermOfCarryingOut)= 11;";
            
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                Console.WriteLine();
                while(reader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}грн", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
                }
                Console.WriteLine();
            }

        }

        public void TakeConferencesOrganizer(SqlConnection connection)
        {
            Console.WriteLine("\nPlease enter unit: ");
            string organizer = Console.ReadLine();
            String sqlCommand = "Select org.Organizer, con.NameOfConf, con.Topic, c.Cost from Organizers org Right join Conferences con on org.OrganizerId = con.OrganizerId Left Join ConfCost c on con.ConfId = c.ConfId where org.Organizer = @Organizer";
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlParameter OrganizerParam = new SqlParameter("@Organizer", organizer);
            command.Parameters.Add(OrganizerParam);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                Console.WriteLine();
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t\t{1}\t{2}\t{3}грн", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3));
                }
                Console.WriteLine();
            }
        }

        public void ConferenceYearPlaceOrganizer(SqlConnection connection)
        {
            Console.WriteLine("Please, enter Place and Organizer: ");
            string place = Console.ReadLine();
            string organizer = Console.ReadLine();
            String sqlCommand = @"Select con.NameOfConf, con.Topic, t.TermOfCarryingOut, p.Place, org.Organizer, c.Cost from Conferences con
                                     Right join Terms t on con.ConfId = t.ConfId
                                     Join Organizers org on con.OrganizerId = org.OrganizerId
                                     Join Places p on org.OrganizerId = p.OrganizerId
                                     Left Join ConfCost c on con.ConfId = c.ConfId
                                     where YEAR(t.TermOfCarryingOut) = 2020
                                     and p.Place = @place 
                                     and org.Organizer = @Organizer;";
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlParameter placeParam = new SqlParameter("@place", place);
            command.Parameters.Add(placeParam);
            SqlParameter OrganizerParam = new SqlParameter("@Organizer", organizer);
            command.Parameters.Add(OrganizerParam);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t\t{5}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4), reader.GetName(5));
                Console.WriteLine();
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t\t{5}грн", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5));
                }
                Console.WriteLine();
            }
        }

        public void Autoconnection(SqlConnection connection)
        {

            SqlDataAdapter adapter = new SqlDataAdapter("Select NameOfConf, Topic from Conferences", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine(dt.TableName); // название таблицы
                                                 // перебор всех столбцов
                foreach (DataColumn column in dt.Columns)
                    Console.Write("\t{0}", column.ColumnName);
                Console.WriteLine();
                // перебор всех строк таблицы
                foreach (DataRow row in dt.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        Console.Write("\t{0}", cell);
                    Console.WriteLine();
                }
            }
        }
    }
}
