using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class RequestAirplaneServiceMap : VersionedClassMap<RequestAirplaneService>
    {

        public RequestAirplaneServiceMap()
        {
            Table("RequestAirplaneService");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.OrdersItem).Column("ORDER_ID");
            References(x => x.RequestStatusItem).Column("REQUEST_STATUS_ID");
            References(x => x.UserItem).Column("USER_ID");
            Map(x => x.IsChanged).Column("IS_CHANGED");
            Map(x => x.SubmitDate).Column("SUBMIT_DATE");
            Map(x => x.Description).Column("DESCRIPTION");
            Map(x => x.IsActiveRequest).Column("IS_ACTIVE_REQUEST");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.RequestAirplaneTicketS).KeyColumn("AIRPLANE_SERVICE_ID");
        }
    }
}
