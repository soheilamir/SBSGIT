using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class ConditionValueMap : VersionedClassMap<ConditionValues>
    {

        public ConditionValueMap()
        {
            Table("ConditionValue");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.FlightConditionItem).Column("FLIGHT_CONDITION_ID");
            Map(x => x.ConditionKey).Column("CONDITION_KEY");
            Map(x => x.ConditionValue).Column("CONDITION_VALUE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
