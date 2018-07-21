using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class FlightStopOverMap : VersionedClassMap<FlightStopOver>
    {
        public FlightStopOverMap()
        {
            Table("FlightStopOver");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.FlightNumberItem).Column("FLIGHT_NUMBER_ID");
            References(x => x.StopCity).Column("STOP_CITY_ID");
            Map(x => x.StopTime).Column("STOP_TIME");
        }
    }
}
