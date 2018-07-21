using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class CityNameByLanguageMap : VersionedClassMap<CityNameByLanguage>
    {
        public CityNameByLanguageMap()
        {
            Table("CityNameByLanguage");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.LanguagesItem).Column("LANGUAGE_ID");
            References(x => x.CityItem).Column("CITY_ID");
            Map(x => x.Name).Column("NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
