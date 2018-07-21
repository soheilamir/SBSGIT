using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class InsuranceZoneMap : VersionedClassMap<InsuranceZone> {
        
        public InsuranceZoneMap() {
			Table("InsuranceZone");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.InternationalInsuranceCompanyItem).Column("INTERNATIONAL_INSURANCE_COMPANY_ID");
			Map(x => x.Name).Column("NAME");
			Map(x => x.MaximumPrice).Column("MAXIMUM_PRICE");
			HasMany(x => x.InsuranceCoverageS).KeyColumn("INSURANCE_ZONE_ID");
			HasMany(x => x.InsurancePriceTableS).KeyColumn("INSURANCE_ZONE_ID");
			HasMany(x => x.InsuranceZoneCountryS).KeyColumn("INSURANCE_ZONE_ID");
        }
    }
}
