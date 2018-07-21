using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirlineClassesMap : VersionedClassMap<AirlineClasses>
    {
        public AirlineClassesMap()
        {
            Table("AirlineClasses");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.AirlineItem).Column("AIRLINE_ID");
            Map(x => x.FlightClassName).Column("FLIGHT_CLASS_NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.AirlineSubClassesS).KeyColumn("AIRLINE_CLASS_ID");
        }
    }
}
