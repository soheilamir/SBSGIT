using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class OnlineFlightTicketMap : VersionedClassMap<OnlineFlightTicket>
    {

        public OnlineFlightTicketMap()
        {
            Table("OnlineFlightTicket");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.ServicesItem).Column("SERVICE_ID");
            References(x => x.OrdersItem).Column("ORDER_ID");
            Map(x => x.PNR).Column("PNR");
            Map(x => x.TicketDate).Column("TICKET_DATE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.OnlineFlightTicketPassengersS).KeyColumn("ONLINE_FLIGHT_TICKET_ID");
            HasMany(x => x.OnlineFlightTicketPathS).KeyColumn("ONLINE_FLIGHT_TICKET_ID");
        }
    }

}
