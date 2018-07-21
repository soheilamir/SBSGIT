using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class InsuranceCoverage
    {
        public long Id { get; set; }
        public InsuranceZone InsuranceZoneItem { get; set; }
        public string CoverageCase { get; set; }
    }
}
