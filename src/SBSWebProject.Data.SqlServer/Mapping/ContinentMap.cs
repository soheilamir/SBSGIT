using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class ContinentMap : VersionedClassMap<Continent>
    {

        public ContinentMap()
        {
            Table("Continent");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.ContinentName).Column("CONTINENT_NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.CountryS).KeyColumn("CONTINENT_ID");
        }
    }
}
