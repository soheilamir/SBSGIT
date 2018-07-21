using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelPhotosMap : VersionedClassMap<HotelPhotos>
    {

        public HotelPhotosMap()
        {
            Table("HotelPhotos");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelItem).Column("HOTEL_ID");
            References(x => x.FileItem).Column("PHOTO_ID");
            Map(x => x.Description).Column("DESCRIPTION");
        }
    }
}
