using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class UserAddressesMap : VersionedClassMap<UserAddresses>
    {
        public UserAddressesMap()
        {
            Table("UserAddresses");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("USER_ID");
            Map(x => x.Address).Column("ADDRESS");
            Map(x => x.AddressType).Column("ADDRESS_TYPE");
            Map(x => x.PostalCode).Column("POSTAL_CODE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.UserTelsS).KeyColumn("USER_ADDRESS_ID");
        }
    }
}
