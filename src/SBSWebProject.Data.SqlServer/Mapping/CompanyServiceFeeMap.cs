using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class CompanyServiceFeeMap : VersionedClassMap<CompanyServiceFee>
    {
        public CompanyServiceFeeMap()
        {
            Table("CompanyServiceFee");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.CompanyItem).Column("COMPANY_ID");
            References(x => x.ServiceItem).Column("SERVICE_ID");
            Map(x => x.ServiceFee).Column("SERVICE_FEE");
            Map(x => x.IsPercent).Column("IS_PERCENT");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
