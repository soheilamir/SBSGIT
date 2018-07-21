using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class ServicesMap : VersionedClassMap<Services>
    {
        public ServicesMap()
        {
            Table("Services");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.SbssectionsItem).Column("SECTION_ID");
            Map(x => x.ServiceName).Column("SERVICE_NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.CompanyServiceFeeS).KeyColumn("SERVICE_ID");
            HasMany(x => x.OnlineFlightTicketS).KeyColumn("SERVICE_ID");
        }
    }
}
