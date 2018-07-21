using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class InsuranceOrdersMap : VersionedClassMap<InsuranceOrders> {
        
        public InsuranceOrdersMap() {
			Table("InsuranceOrders");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.InsurancePriceTableItem).Column("INSURANCE_PRICE_ID");
			References(x => x.PersonsItem).Column("PERSONS_ID");
			Map(x => x.SubmitDate).Column("SUBMIT_DATE");
			Map(x => x.IssuanceDate).Column("ISSUANCE_DATE");
			Map(x => x.TravelStartDate).Column("TRAVEL_START_DATE");
			Map(x => x.TravelEndDate).Column("TRAVEL_END_DATE");
        }
    }
}
