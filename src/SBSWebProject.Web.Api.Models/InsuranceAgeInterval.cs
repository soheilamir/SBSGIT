using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public partial class InsuranceAgeInterval {
        public long Id { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public IList<InsurancePriceTable> InsurancePriceTableS { get; set; }
    }
}
