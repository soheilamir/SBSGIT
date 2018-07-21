using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class InsuranceCoverageMap : VersionedClassMap<InsuranceCoverage> {
        
        public InsuranceCoverageMap() {
			Table("InsuranceCoverage");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.InsuranceZoneItem).Column("INSURANCE_ZONE_ID");
			Map(x => x.CoverageCase).Column("COVERAGE_CASE");
        }
    }
}
