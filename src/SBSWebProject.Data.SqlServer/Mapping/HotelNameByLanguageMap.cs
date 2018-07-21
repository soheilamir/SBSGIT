using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelNameByLanguageMap : VersionedClassMap<HotelNameByLanguage>
    {

        public HotelNameByLanguageMap()
        {
            Table("HotelNameByLanguage");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.LanguagesItem).Column("LANGUAGE_ID");
            References(x => x.HotelItem).Column("HOTEL_ID");
            Map(x => x.Name).Column("NAME");
        }
    }
}
