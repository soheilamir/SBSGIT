using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class DomesticFlightTicketModel
    {
        public string DepartingDate { set; get; }
        public string ReturningDate { set; get; }

        public City Source { set; get; }
        public City Destination { set; get; }
        public JournyTypeModel JourneyType { set; get; }
        public PersonNumberModel Adult { set; get; }
        public PersonNumberModel Child { set; get; }
        public PersonNumberModel Infant { set; get; }
        public DomesticAirlineSelectedListModel DomesticAirline { set; get; }
    }
}
