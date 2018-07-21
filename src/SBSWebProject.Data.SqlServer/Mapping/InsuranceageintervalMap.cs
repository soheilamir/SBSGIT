using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class InsuranceAgeIntervalMap : VersionedClassMap<InsuranceAgeInterval> {
        
        public InsuranceAgeIntervalMap() {
			Table("InsuranceAgeInterval");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.FromYear).Column("FROM_YEAR");
			Map(x => x.ToYear).Column("TO_YEAR");
			HasMany(x => x.InsurancePriceTableS).KeyColumn("INSURANCE_AGE_INTERVAL_ID");
        }
    }
}
