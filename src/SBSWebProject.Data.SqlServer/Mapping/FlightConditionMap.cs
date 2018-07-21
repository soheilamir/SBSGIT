using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class FlightConditionMap : VersionedClassMap<FlightCondition>
    {

        public FlightConditionMap()
        {
            Table("FlightCondition");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.AirlinesItem).Column("AIRLINE_ID");
            //References(x => x.FlightNumberItem).Column("FLIGHT_NUMBER_ID");
            References(x => x.ConditionTypeItem).Column("CONDITION_TYPE_ID");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.ConditionValuesS).KeyColumn("FLIGHT_CONDITION_ID");
        }
    }
}
