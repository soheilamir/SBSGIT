using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class OrdersMap : VersionedClassMap<Orders>
    {

        public OrdersMap()
        {
            Table("Orders");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("USER_ID");
            References(x => x.CompanyItem).Column("COMPANY_ID");
            References(x => x.OrderStatusItem).Column("ORDER_STATUS_ID");
            Map(x => x.SubmitDateTime).Column("SUBMIT_DATE_TIME");
            Map(x => x.CompletionDateTime).Column("COMPLETION_DATE_TIME");
            Map(x => x.IsHealthSave).Column("IS_HEALTH_SAVE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.CompanyAttachmentS).KeyColumn("ORDER_ID");
            HasMany(x => x.OnlineFlightTicketS).KeyColumn("ORDER_ID");
            HasMany(x => x.RequestAirplaneServiceS).KeyColumn("ORDER_ID");
        }
    }
}
