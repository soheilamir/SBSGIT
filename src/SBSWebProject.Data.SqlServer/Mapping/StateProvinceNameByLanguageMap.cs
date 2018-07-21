using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class StateProvinceNameByLanguageMap : VersionedClassMap<StateProvinceNameByLanguage>
    {

        public StateProvinceNameByLanguageMap()
        {
            Table("StateProvinceNameByLanguage");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.StateProvinceItem).Column("STATE_PROVINCE_ID");
            References(x => x.LanguagesItem).Column("LANGUAGE_ID");
            Map(x => x.StateProvinceName).Column("STATE_PROVINCE_NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
