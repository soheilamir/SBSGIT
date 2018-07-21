using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class EarthRegionMap : VersionedClassMap<EarthRegion>
    {

        public EarthRegionMap()
        {
            Table("EarthRegion");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.EarthRegionName).Column("EARTH_REGION_NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.CountryS).KeyColumn("EARTH_REGION_ID");
        }
    }
}
