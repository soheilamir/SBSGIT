using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class OnlineFlightTicketPathMap : VersionedClassMap<OnlineFlightTicketPath>
    {
        public OnlineFlightTicketPathMap()
        {
            Table("OnlineFlightTicketPath");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.OnlineFlightTicketItem).Column("ONLINE_FLIGHT_TICKET_ID");
            References(x => x.AirlineClassPathFeeItem).Column("AIRLINE_CLASS_PATH_FEE_ID");
            Map(x => x.DeparturDate).Column("DEPARTUR_DATE");
            HasMany(x => x.OnlineFlightTicketPassengersS).KeyColumn("ONLINE_FLIGHT_TICKET_PATH_ID");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
