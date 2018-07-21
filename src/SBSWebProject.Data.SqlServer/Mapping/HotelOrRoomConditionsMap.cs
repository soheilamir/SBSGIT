using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelOrRoomConditionsMap : VersionedClassMap<HotelOrRoomConditions>
    {

        public HotelOrRoomConditionsMap()
        {
            Table("HotelOrRoomConditions");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelItem).Column("HOTEL_ID");
            References(x => x.HotelroomItem).Column("HOTEL_ROOM_ID");
            Map(x => x.Condition).Column("CONDITION");
        }
    }
}
