using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class TicketNumberMap : VersionedClassMap<TicketNumbers>
    {

        public TicketNumberMap()
        {
            Table("TicketNumber");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.ResponseAirplaneTicketItem).Column("RESPONSE_AIRPLANE_TICKET_ID");
            References(x => x.PassengersItem).Column("PASSENGER_ID");
            Map(x => x.TicketNumber).Column("TICKET_NUMBER");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
