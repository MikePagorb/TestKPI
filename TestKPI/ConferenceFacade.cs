using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data;

namespace TestKPI
{
    class ConferenceFacade
    {
        ConnectionToDB connect;
        Selections selections;
        CreatorConferences creatorConferences;
        public ConferenceFacade (ConnectionToDB connect, Selections selections, CreatorConferences creatorConferences)
        {
            this.connect = connect;
            this.selections = selections;
            this.creatorConferences = creatorConferences;
        }
        public void TakeConferencesForMextKvartal()
        {
            connect.SetConnection();
            try
            {
                connect.ConnectionDB.Open();
                Console.WriteLine("Connection open");
                selections.TakeConferencesNextKvartal(connect.ConnectionDB);
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

        public void TakeUnitInConferences()
        {
            connect.SetConnection();
            try
            {
                connect.ConnectionDB.Open();
                Console.WriteLine("Connection open");
                selections.TakeConferencesOrganizer(connect.ConnectionDB);
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

        public void TakeConferenceThisYear()
        {
            connect.SetConnection();
            try
            {
                connect.ConnectionDB.Open();
                Console.WriteLine("Connection open");
                selections.ConferenceYearPlaceOrganizer(connect.ConnectionDB);
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

        public void CreateConferencesOnTheNextYear()
        {
            connect.SetConnection();
            try
            {
                connect.ConnectionDB.Open();
                Console.WriteLine("Connection open");
                creatorConferences.CreateConferencesNextYear(connect.ConnectionDB);
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
        public void AutoConnect()
        {
            connect.SetConnection();
            try
            {
                connect.ConnectionDB.Open();
                Console.WriteLine("Connection open");
                selections.Autoconnection(connect.ConnectionDB);
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
