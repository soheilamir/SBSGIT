using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirlinesMap : VersionedClassMap<Airlines>
    {
        public AirlinesMap()
        {
            Table("AirLines");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.CountryItem).Column("COUNTRY_ID");
            Map(x => x.Name).Column("NAME");
            Map(x => x.FlightStateCode).Column("FLIGHT_STATE_CODE");
            Map(x => x.Type).Column("TYPE");
            Map(x => x.IataCode).Column("IATA_CODE");
            Map(x => x.IacoCode).Column("IACO_CODE");
            Map(x => x.Include).Column("INCLUDE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.AirlineClassesS).KeyColumn("AIRLINE_ID");
            HasMany(x => x.AirlineMembersS).KeyColumn("AIRLINE_ID");
            HasMany(x => x.AirlineNameByLanguageS).KeyColumn("AIRLINE_ID");
            HasMany(x => x.AirlineSubClassesS).KeyColumn("AIRLINE_ID");
            HasMany(x => x.FlightConditionS).KeyColumn("AIRLINE_ID");
            HasMany(x => x.UserFavoriteAirlinesS).KeyColumn("AIRLINE_ID");
            HasMany(x => x.AirplaneTicketPreferedAirlinesS).KeyColumn("AIRLINE_ID");
        }
    }
}
