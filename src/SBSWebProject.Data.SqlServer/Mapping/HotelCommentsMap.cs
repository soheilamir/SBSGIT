using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelCommentsMap : VersionedClassMap<HotelComments>
    {

        public HotelCommentsMap()
        {
            Table("HotelComments");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelItem).Column("HOTEL_ID");
            References(x => x.UserItem).Column("USER_ID");
            Map(x => x.Comments).Column("COMMENTS");
            Map(x => x.Date).Column("DATE");
        }
    }
}
