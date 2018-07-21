using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class CountryMap : VersionedClassMap<Country>
    {

        public CountryMap()
        {
            Table("Country");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.EarthRegionItem).Column("EARTH_REGION_ID");
            References(x => x.ContinentItem).Column("CONTINENT_ID");
            Map(x => x.DialingCode).Column("DIALING_CODE");
            Map(x => x.IsoCode).Column("ISO_CODE");
            Map(x => x.UnCode).Column("UN_CODE");
            Map(x => x.UnNum).Column("UN_NUM");
            Map(x => x.FlagUrl).Column("FLAG_URL");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.AirlinesS).KeyColumn("COUNTRY_ID");
            HasMany(x => x.CountryIpAddressesS).KeyColumn("COUNTRY_ID");
            HasMany(x => x.CountryNameByLanguageS).KeyColumn("COUNTRY_ID");
            HasMany(x => x.InsuranceZoneCountryS).KeyColumn("COUNTRY_ID");
            HasMany(x => x.StateProvinceS).KeyColumn("COUNTRY_ID");
            HasMany(x => x.UserLoginLogS).KeyColumn("COUNTRY_ID");
        }
    }
}
