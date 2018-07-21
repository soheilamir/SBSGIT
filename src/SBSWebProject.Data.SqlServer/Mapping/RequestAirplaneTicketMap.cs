using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class RequestAirplaneTicketMap : VersionedClassMap<RequestAirplaneTicket>
    {

        public RequestAirplaneTicketMap()
        {
            Table("RequestAirplaneTicket");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.RequestAirplaneServiceItem).Column("AIRPLANE_SERVICE_ID");
            References(x => x.SourceCityItem).Column("SOURCE_CITY_ID");
            References(x => x.DestinationCityItem).Column("DESTINATION_CITY_ID");
            References(x => x.PlaneTicketStatusId).Column("PLANE_TICKET_STATUS_ID");
            Map(x => x.AdminUserId).Column("ADMIN_USER_ID");
            Map(x => x.TicketClass).Column("TICKET_CLASS");
            Map(x => x.TicketType).Column("TICKET_TYPE");
            Map(x => x.JourneyType).Column("JOURNEY_TYPE");
            Map(x => x.IsDateFlexible).Column("IS_DATE_FLEXIBLE");
            Map(x => x.PreferredTime).Column("PREFERRED_TIME");
            Map(x => x.DepartureDate).Column("DEPARTURE_DATE");
            Map(x => x.ReturningDate).Column("RETURNING_DATE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.RequestAirplaneTicketPassengerS).KeyColumn("PLANE_TICKET_ID");
            HasMany(x => x.ResponseAirplaneTicketS).KeyColumn("REQUEST_AIRPLANE_TICKET_ID");
            HasMany(x => x.AirplaneTicketPreferedAirlinesS).KeyColumn("REQUEST_AIRPLANE_TICKET_ID");
        }
    }
}
