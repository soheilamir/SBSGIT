using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class IranianInsuranceCompany
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public IList<InternationalInsuranceCompany> InternationalInsuranceCompanyS { get; set; }
    }
}
