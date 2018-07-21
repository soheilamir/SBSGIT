using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class InternationalInsuranceCompany
    {
        public long Id { get; set; }
        public IranianInsuranceCompany IranianInsuranceCompanyItem { get; set; }
        public string CompanyName { get; set; }
        public IList<InsuranceZone> InsuranceZoneS { get; set; }
    }
}
