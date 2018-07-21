    using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class CityMap : VersionedClassMap<City>
    {
        public CityMap()
        {
            Table("City");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.StateProvinceItem).Column("STATE_PROVINCE_ID");
            Map(x => x.TelCode).Column("TEL_CODE");
            Map(x => x.CharCode).Column("CHAR_CODE");
            Map(x => x.IsCapital).Column("IS_CAPITAL");
            Map(x => x.Priority).Column("PRIORITY");
            Map(x => x.CityMapFile).Column("CITY_MAP_FILE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.AirportsS).KeyColumn("CITY_ID");
            HasMany(x => x.CityNameByLanguageS).KeyColumn("CITY_ID");
            HasMany(x => x.CityPublicPlaceS).KeyColumn("CITY_ID");
            HasMany(x => x.DestinationCityFlightPathS).KeyColumn("DESTINATION_CITY_ID");
            HasMany(x => x.SourceCityFlightPathS).KeyColumn("SOURCE_CITY_ID");
            HasMany(x => x.FlightStopOverS).KeyColumn("STOP_CITY_ID");
            HasMany(x => x.BirthPlacePassengerS).KeyColumn("BIRTH_PALACE_CITY_ID");
            HasMany(x => x.RequestDestinationAirplaneTicketS).KeyColumn("DESTINATION_CITY_ID");
            HasMany(x => x.RequestSourceAirplaneTicketS).KeyColumn("SOURCE_CITY_ID");
            HasMany(x => x.Sbsbranches).KeyColumn("CITY_ID");
            HasMany(x => x.BirthPlaceUserS).KeyColumn("BIRTH_PALACE_CITY_ID");
            HasMany(x => x.LeavingPlaceUserS).KeyColumn("LIVING_CITY_ID");
        }
    }
}
