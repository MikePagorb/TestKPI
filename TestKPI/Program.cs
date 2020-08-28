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

            ConnectionToDB connection = new ConnectionToDB();
            Selections selections = new Selections();
            CreatorConferences creatorConferences = new CreatorConferences();

            ConferenceFacade con = new ConferenceFacade(connection, selections, creatorConferences);
            User user = new User();
            user.CreateSelections(con);
        }
    }
}
