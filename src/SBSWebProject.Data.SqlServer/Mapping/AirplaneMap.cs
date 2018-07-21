using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirplaneMap : VersionedClassMap<Airplane>
    {
        public AirplaneMap()
        {
            Table("Airplane");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.Company).Column("COMPANY");
            Map(x => x.Name).Column("NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.FlightNumberS).KeyColumn("AIRPLANE_ID");
        }
    }
}
