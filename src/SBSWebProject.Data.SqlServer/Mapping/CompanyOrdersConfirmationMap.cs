using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class CompanyOrdersConfirmationMap : VersionedClassMap<CompanyOrdersConfirmation> {
        
        public CompanyOrdersConfirmationMap() {
			Table("CompanyOrdersConfirmation");
            LazyLoad();
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
			References(x => x.OrdersItem).Column("ORDER_ID");
			References(x => x.CompanyEmployeeItem).Column("EMPLOYEE_ID");
			Map(x => x.ConfirmLevel).Column("CONFIRM_LEVEL");
			Map(x => x.IsConfirm).Column("IS_CONFIRM");
			//Map(x => x.State).Column("STATE");
			//Map(x => x.Ts).Column("TS");
        }
    }
}
