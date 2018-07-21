using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelRoomPhotosMap : VersionedClassMap<HotelRoomPhotos>
    {

        public HotelRoomPhotosMap()
        {
            Table("HotelRoomPhotos");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelRoomItem).Column("HOTEL_ROOM_ID");
            References(x => x.FileItem).Column("PHOTO_ID");
            Map(x => x.Descriptopn).Column("DESCRIPTOPN");
        }
    }
}
