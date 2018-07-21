using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirportsMap : VersionedClassMap<Airports>
    {
        public AirportsMap()
        {
            Table("Airports");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.CityItem).Column("CITY_ID");
            Map(x => x.Address).Column("ADDRESS");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.AirportNamebyLanguageS).KeyColumn("AIRPORT_ID");
        }
    }
}
