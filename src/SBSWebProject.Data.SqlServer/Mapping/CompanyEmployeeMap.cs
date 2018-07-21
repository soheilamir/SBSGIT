using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class CompanyEmployeeMap : VersionedClassMap<CompanyEmployee>
    {
        public CompanyEmployeeMap()
        {
            Table("CompanyEmployee");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.CompanyItem).Column("COMPANY_ID");
            References(x => x.UserItem).Column("USER_ID");
            Map(x => x.IsManager).Column("IS_MANAGER");
            References(x => x.CompanyEmployeePositionItem).Column("POSITION_ID");
            Map(x => x.IsSeo).Column("IS_SEO");
            Map(x => x.RequestDate).Column("REQUEST_DATE");
            Map(x => x.IsAcceptedUser).Column("IS_ACCEPTED_USER");
            Map(x => x.AcceptedUserDate).Column("ACCEPT_USER_DATE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}

