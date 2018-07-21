using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class UserFavoriteAirlinesMap : VersionedClassMap<UserFavoriteAirlines>
    {
        public UserFavoriteAirlinesMap()
        {
            Table("UserFavoriteAirlines");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("USER_ID");
            References(x => x.AirlinesItem).Column("AIRLINE_ID");
            Map(x => x.FromCityId).Column("FROM_CITY_ID");
            Map(x => x.ToCityId).Column("TO_CITY_ID");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
