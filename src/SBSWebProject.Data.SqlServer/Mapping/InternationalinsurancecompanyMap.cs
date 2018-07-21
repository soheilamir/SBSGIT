using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class InternationalInsuranceCompanyMap : VersionedClassMap<InternationalInsuranceCompany> {
        
        public InternationalInsuranceCompanyMap() {
			Table("InternationalInsuranceCompany");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.IranianInsuranceCompanyItem).Column("IRANIAN_INSURANCE_COMPANY_ID");
			Map(x => x.CompanyName).Column("COMPANY_NAME");
			HasMany(x => x.InsuranceZoneS).KeyColumn("INTERNATIONAL_INSURANCE_COMPANY_ID");
        }
    }
}
