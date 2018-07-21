using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirlineSubClassesMap : VersionedClassMap<AirlineSubClasses>
    {

        public AirlineSubClassesMap()
        {
            Table("AirlineSubClasses");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            References(x => x.AirlinesItem).Column("AIRLINE_ID");
            References(x => x.AirlineClassesItem).Column("AIRLINE_CLASS_ID");
            Map(x => x.AirlineSubClassName).Column("AIRLINE_SUB_CLASS_NAME");
            Map(x => x.IsActive).Column("IS_ACTIVE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.AirlineClassPathS).KeyColumn("AIRLINE_SUB_CLASS_ID");
            HasMany(x => x.FlightNumbersS).KeyColumn("AIRLINE_SUB_CLASS_ID");
        }
    }
}
