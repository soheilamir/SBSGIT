using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class FlightPathMap : VersionedClassMap<FlightPath>
    {
        public FlightPathMap()
        {
            Table("FlightPath");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.SourceCityItem).Column("SOURCE_CITY_ID");
            References(x => x.DestinationCityItem).Column("DESTINATION_CITY_ID");
            HasMany(x => x.AirlineClassPathS).KeyColumn("FLIGHT_PATH_ID");
        }
    }
}
