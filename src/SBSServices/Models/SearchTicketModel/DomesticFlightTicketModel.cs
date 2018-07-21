using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebSiteAPI.Models.SearchTicketModel;

namespace SBSWebSiteAPI.Models.SearchTicketModel
{
    public class DomesticFlightTicketModel
    {
        public string DepartingDate { set; get; }
        public string ReturningDate { set; get; }

        public SourceModel Source { set; get; }
        public DestinationModel Destination { set; get; }
        public JournyTypeModel JourneyType { set; get; }
        public PersonNumberModel Adult { set; get; }
        public PersonNumberModel Child { set; get; }
        public PersonNumberModel Infant { set; get; }
        public DomesticAirlineSelectedListModel DomesticAirline { set; get; }
    }
}