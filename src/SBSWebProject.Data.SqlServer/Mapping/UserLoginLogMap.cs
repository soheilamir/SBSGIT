using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class UserLoginLogMap : VersionedClassMap<UserLoginLog>
    {
        public UserLoginLogMap()
        {
            Table("UserLoginLog");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("USER_ID");
            References(x => x.CountryItem).Column("COUNTRY_ID");
            Map(x => x.Date).Column("DATE");
            Map(x => x.LocationIp).Column("LOCATION_IP");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
