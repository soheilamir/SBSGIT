using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class LanguagesMap : VersionedClassMap<Languages>
    {

        public LanguagesMap()
        {
            Table("Languages");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.LanguageName).Column("LANGUAGE_NAME");
            Map(x => x.ISO6391).Column("ISO_639_1");
            Map(x => x.ISO6392).Column("ISO_639_2");
            Map(x => x.TextDirection).Column("TEXT_DIRECTION");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.AirlineNameByLanguageS).KeyColumn("LANGUAGE_ID");
            HasMany(x => x.AirportNameByLanguageS).KeyColumn("LANGUAGE_ID");
            HasMany(x => x.CityNameByLanguageS).KeyColumn("LANGUAGE_ID");
            HasMany(x => x.CityPublicPlaceNameByLanguageS).KeyColumn("LANGUAGE_ID");
            HasMany(x => x.CountryNameByLanguageS).KeyColumn("LANGUAGE_ID");
            HasMany(x => x.FacilitiesNameByLanguageS).KeyColumn("LANGUAGE_ID");
            HasMany(x => x.HotelNameByLanguageS).KeyColumn("LANGUAGE_ID");
            HasMany(x => x.StateProvinceNameByLanguageS).KeyColumn("LANGUAGE_ID");
            HasMany(x => x.UserLanguagesS).KeyColumn("LANGUAGE_ID");
            HasMany(x => x.HotelRoomTypeNameByLanguageS).KeyColumn("LANGUAGE_ID");
        }
    }
}
