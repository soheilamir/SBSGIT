using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class OnlineFlightTicketPassengersMap : VersionedClassMap<OnlineFlightTicketPassengers>
    {
        public OnlineFlightTicketPassengersMap()
        {
            Table("OnlineFlightTicketPassengers");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.OnlineFlightTicketItem).Column("ONLINE_FLIGHT_TICKET_ID");
            References(x => x.OnlineFlightTicketPathItem).Column("ONLINE_FLIGHT_TICKET_PATH_ID");
            References(x => x.PassengersItem).Column("PASSENGERS_ID");
            Map(x => x.TicketNumber).Column("TICKET_NUMBER");
        }
    }
}
