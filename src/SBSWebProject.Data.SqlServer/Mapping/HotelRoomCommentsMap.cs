using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelRoomCommentsMap : VersionedClassMap<HotelRoomComments>
    {

        public HotelRoomCommentsMap()
        {
            Table("HotelRoomComments");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelRoomItem).Column("HOTEL_ROOM_ID");
            References(x => x.UserItem).Column("USER_ID");
            Map(x => x.Comments).Column("COMMENTS");
        }
    }
}
