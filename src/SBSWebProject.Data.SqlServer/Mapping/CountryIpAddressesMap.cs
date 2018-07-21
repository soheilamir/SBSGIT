using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class CountryIpAddressesMap : VersionedClassMap<CountryIpAddresses>
    {

        public CountryIpAddressesMap()
        {
            Table("CountryIpAddresses");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.CountryItem).Column("COUNTRY_ID");
            Map(x => x.FromIp).Column("FROM_IP");
            Map(x => x.ToIp).Column("TO_IP");
            Map(x => x.Owner).Column("OWNER");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
