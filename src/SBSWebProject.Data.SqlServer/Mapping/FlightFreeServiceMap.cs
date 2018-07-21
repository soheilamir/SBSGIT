using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class FlightFreeServiceMap : VersionedClassMap<FlightFreeServices>
    {

        public FlightFreeServiceMap()
        {
            Table("FlightFreeService");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.FlightNumberItem).Column("FLIGHT_NUMBER_ID");
            Map(x => x.ServiceName).Column("SERVICE_NAME");
            Map(x => x.ServiceDescription).Column("SERVICE_DESCRIPTION");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
