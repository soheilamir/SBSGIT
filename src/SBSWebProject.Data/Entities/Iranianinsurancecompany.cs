using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class IranianInsuranceCompany : Entity {
        public virtual string CompanyName { get; set; }
        public virtual IList<InternationalInsuranceCompany> InternationalInsuranceCompanyS { get; set; }
    }
}
