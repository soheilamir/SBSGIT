using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class InsuranceZone
    {
        public long Id { get; set; }
        public InternationalInsuranceCompany InternationalInsuranceCompanyItem { get; set; }
        public string Name { get; set; }
        public string MaximumPrice { get; set; }
        public IList<InsuranceCoverage> InsuranceCoverageS { get; set; }
        public IList<InsurancePriceTable> InsurancePriceTableS { get; set; }
        public IList<InsuranceZoneCountry> InsuranceZoneCountryS { get; set; }
    }
}
