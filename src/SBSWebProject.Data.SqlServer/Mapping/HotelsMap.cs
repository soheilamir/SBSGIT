using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelsMap : VersionedClassMap<Hotels>
    {

        public HotelsMap()
        {
            Table("Hotels");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.CityItem).Column("CITY_ID");
            Map(x => x.Stars).Column("STARS");
            Map(x => x.Rate).Column("RATE");
            Map(x => x.Description).Column("DESCRIPTION");
            Map(x => x.FreeWifi).Column("FREE_WIFI");
            Map(x => x.Address).Column("ADDRESS");
            HasMany(x => x.HotelAccessibilityS).KeyColumn("HOTEL_ID");
            HasMany(x => x.HotelCommentsS).KeyColumn("HOTEL_ID");
            HasMany(x => x.HotelFacilitiesS).KeyColumn("HOTEL_ID");
            HasMany(x => x.HotelNameByLanguageS).KeyColumn("HOTEL_ID");
            HasMany(x => x.HotelOrRoomConditionsS).KeyColumn("HOTEL_ID");
            HasMany(x => x.HotelPhotosS).KeyColumn("HOTEL_ID");
            HasMany(x => x.HotelRoomS).KeyColumn("HOTEL_ID");
        }
    }
}
