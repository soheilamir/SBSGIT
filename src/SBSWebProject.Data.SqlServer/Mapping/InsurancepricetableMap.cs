using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class InsurancePriceTableMap : VersionedClassMap<InsurancePriceTable> {
        
        public InsurancePriceTableMap() {
			Table("InsurancePriceTable");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.InsuranceZoneItem).Column("INSURANCE_ZONE_ID");
			References(x => x.InsuranceTravelIntervalItem).Column("INSURANCE_TRAVEL_INTERVAL_ID");
			References(x => x.InsuranceAgeIntervalItem).Column("INSURANCE_AGE_INTERVAL_ID");
			Map(x => x.Price).Column("PRICE");
			HasMany(x => x.InsuranceOrdersS).KeyColumn("INSURANCE_PRICE_ID");
        }
    }
}
