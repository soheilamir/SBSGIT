using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelAccessibilityMap : VersionedClassMap<HotelAccessibility>
    {

        public HotelAccessibilityMap()
        {
            Table("HotelAccessibility");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelsItem).Column("HOTEL_ID");
            References(x => x.CityPublicPlaceItem).Column("PUBLIC_PLACE_ID");
            Map(x => x.Distance).Column("DISTANCE");
            Map(x => x.TimeWithCar).Column("TIME_WITH_CAR");
            Map(x => x.TimeWithWalk).Column("TIME_WITH_WALK");
        }
    }
}
