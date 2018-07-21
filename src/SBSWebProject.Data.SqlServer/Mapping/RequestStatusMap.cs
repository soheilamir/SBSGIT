using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class RequestStatusMap : VersionedClassMap<RequestStatus>
    {

        public RequestStatusMap()
        {
            Table("RequestStatus");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.Name).Column("NAME");
            Map(x => x.Code).Column("CODE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.OrdersS).KeyColumn("ORDER_STATUS_ID");
            HasMany(x => x.RequestAirplaneServiceS).KeyColumn("REQUEST_STATUS_ID");
            HasMany(x => x.RequestAirplaneTicketS).KeyColumn("PLANE_TICKET_STATUS_ID");
        }
    }
}
