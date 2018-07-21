using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class InsuranceZoneCountryMap : VersionedClassMap<InsuranceZoneCountry> {
        
        public InsuranceZoneCountryMap() {
			Table("InsuranceZoneCountry");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.InsuranceZoneItem).Column("INSURANCE_ZONE_ID");
			References(x => x.CountryItem).Column("COUNTRY_ID");
        }
    }
}
