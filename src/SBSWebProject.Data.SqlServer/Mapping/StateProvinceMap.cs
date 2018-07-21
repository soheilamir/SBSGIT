using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class StateProvinceMap : VersionedClassMap<StateProvince>
    {

        public StateProvinceMap()
        {
            Table("StateProvince");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.CountryItem).Column("COUNTRY_ID");
            Map(x => x.TelCode).Column("TEL_CODE");
            Map(x => x.CharCode).Column("CHAR_CODE");
            Map(x => x.Priority).Column("PRIORITY");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.StateProvinceNameByLanguageS).KeyColumn("STATE_PROVINCE_ID");
            HasMany(x => x.CityS).KeyColumn("STATE_PROVINCE_ID");
        }
    }
}
