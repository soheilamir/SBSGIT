using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class InsuranceZoneCountry
    {
        public long Id { get; set; }
        public InsuranceZone InsuranceZoneItem { get; set; }
        public Country CountryItem { get; set; }
    }
}
