using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class ResponseAirplaneTicketMap : VersionedClassMap<ResponseAirplaneTicket>
    {
        public ResponseAirplaneTicketMap()
        {
            Table("ResponsePlaneTicket");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.RequestAirplaneTicketItem).Column("REQUEST_AIRPLANE_TICKET_ID");
            References(x => x.FlightNumbersItem).Column("FLIGHT_NUMBER_ID");
            Map(x => x.Availability).Column("AVAILABILITY");
            Map(x => x.TicketTime).Column("TICKET_TIME");
            Map(x => x.SbsRecommend).Column("SBS_RECOMMEND");
            Map(x => x.TicketDate).Column("TICKET_DATE");
            Map(x => x.IsReturning).Column("IS_RETURNING");
            Map(x => x.IsSelect).Column("IS_SELECT");
            Map(x => x.AdultPrice).Column("ADULT_PRICE");
            Map(x => x.ChildPrice).Column("CHILD_PRICE");
            Map(x => x.InfantPrice).Column("INFANT_PRICE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.TicketNumberS).KeyColumn("RESPONSE_AIRPLANE_TICKET_ID");
        }
    }
}
