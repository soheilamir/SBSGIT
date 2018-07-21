using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class CountryNameByLanguageMap : VersionedClassMap<CountryNameByLanguage>
    {
        public CountryNameByLanguageMap()
        {
            Table("CountryNameByLanguage");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.LanguagesItem).Column("LANGUAGE_ID");
            References(x => x.CountryItem).Column("COUNTRY_ID");
            Map(x => x.ContryName).Column("CONTRY_NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
