using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKPI
{
    class User
    {
        public void CreateSelections(ConferenceFacade facade)
        {
            facade.TakeConferencesForMextKvartal();
            facade.TakeUnitInConferences();
            facade.TakeConferenceThisYear();
            facade.CreateConferencesOnTheNextYear();
            facade.AutoConnect();
        }
    }
}
