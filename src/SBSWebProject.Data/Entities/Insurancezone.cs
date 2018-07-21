using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class InsuranceZone : Entity {
        public virtual InternationalInsuranceCompany InternationalInsuranceCompanyItem { get; set; }
        public virtual string Name { get; set; }
        public virtual string MaximumPrice { get; set; }
        public virtual IList<InsuranceCoverage> InsuranceCoverageS { get; set; }
        public virtual IList<InsurancePriceTable> InsurancePriceTableS { get; set; }
        public virtual IList<InsuranceZoneCountry> InsuranceZoneCountryS { get; set; }
    }
}
