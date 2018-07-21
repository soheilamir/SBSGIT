using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class InternationalInsuranceCompany : Entity {
        public virtual IranianInsuranceCompany IranianInsuranceCompanyItem { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual IList<InsuranceZone> InsuranceZoneS { get; set; }
    }
}
