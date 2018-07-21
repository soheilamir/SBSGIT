using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class IranianInsuranceCompanyMap : VersionedClassMap<IranianInsuranceCompany> {
        
        public IranianInsuranceCompanyMap() {
			Table("IranianInsuranceCompany");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.CompanyName).Column("COMPANY_NAME");
			HasMany(x => x.InternationalInsuranceCompanyS).KeyColumn("IRANIAN_INSURANCE_COMPANY_ID");
        }
    }
}
