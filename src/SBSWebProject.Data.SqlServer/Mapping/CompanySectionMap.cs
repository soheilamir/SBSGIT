using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class CompanySectionMap : VersionedClassMap<CompanySection> {
        
        public CompanySectionMap() {
			Table("CompanySection");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
			References(x => x.CompanySectionItem).Column("COMPANY_SECTION_ID");
			References(x => x.CompanyItem).Column("COMPANY_ID");
			Map(x => x.SectionName).Column("SECTION_NAME");
			HasMany(x => x.CompanyEmployeeS).KeyColumn("COMPANY_SECTION_ID");
			HasMany(x => x.CompanySectionS).KeyColumn("COMPANY_SECTION_ID");
        }
    }
}
