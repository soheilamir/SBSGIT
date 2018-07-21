using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class UserTelsMap : VersionedClassMap<UserTels>
    {
        public UserTelsMap()
        {
            Table("UserTels");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("USER_ID");
            References(x => x.UserAddressesItem).Column("USER_ADDRESS_ID");
            Map(x => x.TelNumber).Column("TEL_NUMBER");
            Map(x => x.TelType).Column("TEL_TYPE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
