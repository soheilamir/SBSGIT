using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelRoomBedsMap : VersionedClassMap<HotelRoomBeds>
    {

        public HotelRoomBedsMap()
        {
            Table("HotelRoomBeds");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.BedName).Column("BED_NAME");
            Map(x => x.BedWidth).Column("BED_WIDTH");
            Map(x => x.BedHeight).Column("BED_HEIGHT");
            HasMany(x => x.HotelRoomS).KeyColumn("HOTEL_ROOM_BED_ID");
        }
    }
}
