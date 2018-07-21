using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class FlightNumbersMap : VersionedClassMap<FlightNumbers>
    {
        public FlightNumbersMap()
        {
            Table("FlightNumbers");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.AirlineSubClassesItem).Column("AIRLINE_SUB_CLASS_ID");
            References(x => x.AirlineClassPathItem).Column("AIRLINE_CLASS_PATH_ID");
            References(x => x.AirplaneItem).Column("AIRPLANE_ID");
            Map(x => x.FlightNumber).Column("FLIGHT_NUMBER");
            Map(x => x.TakeOffTime).Column("TAKE_OFF_TIME");
            Map(x => x.LandingTime).Column("LANDING_TIME");
            Map(x => x.TransitTime).Column("TRANSIT_TIME");
            Map(x => x.TicketValidation).Column("TICKET_VALIDATION");
            Map(x => x.IsActive).Column("IS_ACTIVE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.FlightFreeServicesesS).KeyColumn("FLIGHT_NUMBER_ID");
            HasMany(x => x.FlightStopOverS).KeyColumn("FLIGHT_NUMBER_ID");
            HasMany(x => x.ResponseAirplaneTicketS).KeyColumn("FLIGHT_NUMBER_ID");
        }
    }
}
