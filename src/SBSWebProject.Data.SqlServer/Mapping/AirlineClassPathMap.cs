using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirlineClassPathMap : VersionedClassMap<AirlineClassPath>
    {
        public AirlineClassPathMap()
        {
            Table("AirlineClassPath");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.AirlineSubClassesItem).Column("AIRLINE_SUB_CLASS_ID");
            References(x => x.FlightPathItem).Column("FLIGHT_PATH_ID");
            Map(x => x.IsActive).Column("IS_ACTIVE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.FlightConditionS).KeyColumn("AIRLINE_CLASS_PATH_ID");
            HasMany(x => x.FlightNumbersS).KeyColumn("AIRLINE_CLASS_PATH_ID");
            HasMany(x => x.AirlineClassPathFeeS).KeyColumn("AIRLINE_CLASS_PATH_ID");
        }
    }
}
