using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelRoomMap : VersionedClassMap<HotelRoom>
    {

        public HotelRoomMap()
        {
            Table("HotelRoom");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelItem).Column("HOTEL_ID");
            References(x => x.HotelRoomBedItem).Column("HOTEL_ROOM_BED_ID");
            References(x => x.HotelRoomTypeItem).Column("ROOM_TYPE_ID");
            Map(x => x.RoomCount).Column("ROOM_COUNT");
            Map(x => x.Dimension).Column("DIMENSION");
            Map(x => x.MaxAdults).Column("MAX_ADULTS");
            Map(x => x.MaxChildren).Column("MAX_CHILDREN");
            Map(x => x.MaxGuests).Column("MAX_GUESTS");
            Map(x => x.ChildNum).Column("CHILD_NUM");
            Map(x => x.ChildAge).Column("CHILD_AGE");
            Map(x => x.HasBreakfast).Column("HAS_BREAKFAST");
            Map(x => x.HasDinner).Column("HAS_DINNER");
            Map(x => x.HasLunch).Column("HAS_LUNCH");
            HasMany(x => x.HotelOrRoomConditionsS).KeyColumn("HOTEL_ROOM_ID");
            HasMany(x => x.HotelRoomCommentsS).KeyColumn("HOTEL_ROOM_ID");
            HasMany(x => x.HotelRoomNightPriceS).KeyColumn("HOTEL_ROOM_ID");
            HasMany(x => x.HotelRoomPhotosS).KeyColumn("HOTEL_ROOM_ID");
        }
    }
}
