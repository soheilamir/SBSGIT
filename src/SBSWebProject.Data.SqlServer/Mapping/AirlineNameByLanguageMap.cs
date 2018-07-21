using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirlineNameByLanguageMap : VersionedClassMap<AirlineNameByLanguage>
    {

        public AirlineNameByLanguageMap()
        {
            Table("AirlineNameByLanguage");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.LanguagesItem).Column("LANGUAGE_ID");
            References(x => x.AirlinesItem).Column("AIRLINE_ID");
            Map(x => x.AirlineName).Column("AIRLINE_NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
