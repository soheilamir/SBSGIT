using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirportNameByLanguageMap : VersionedClassMap<AirportNameByLanguage>
    {
        public AirportNameByLanguageMap()
        {
            Table("AirportNameByLanguage");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.LanguagesItem).Column("LANGUAGE_ID");
            References(x => x.AirportsItem).Column("AIRPORT_ID");
            Map(x => x.AirportName).Column("AIRPORT_NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
