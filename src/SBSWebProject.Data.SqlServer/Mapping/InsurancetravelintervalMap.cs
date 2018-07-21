using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class InsuranceTravelIntervalMap : VersionedClassMap<InsuranceTravelInterval> {
        
        public InsuranceTravelIntervalMap() {
			Table("InsuranceTravelInterval");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.FromDays).Column("FROM_DAYS");
			Map(x => x.ToDays).Column("TO_DAYS");
			Map(x => x.Title).Column("TITLE");
			HasMany(x => x.InsurancePriceTableS).KeyColumn("INSURANCE_TRAVEL_INTERVAL_ID");
        }
    }
}
