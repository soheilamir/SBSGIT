using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelRoomNightPriceMap : VersionedClassMap<HotelRoomNightPrice>
    {
        public HotelRoomNightPriceMap()
        {
            Table("HotelRoomNightPrice");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelRoomItem).Column("HOTEL_ROOM_ID");
            Map(x => x.Date).Column("DATE");
            Map(x => x.Price).Column("PRICE");
            Map(x => x.Description).Column("DESCRIPTION");
            Map(x => x.IsActive).Column("IS_ACTIVE");
        }
    }
}
