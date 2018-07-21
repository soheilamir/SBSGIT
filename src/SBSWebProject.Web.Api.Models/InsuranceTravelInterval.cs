using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class InsuranceTravelInterval
    {
        public long Id { get; set; }
        public int? FromDays { get; set; }
        public int? ToDays { get; set; }
        public string Title { get; set; }
        public IList<InsurancePriceTable> InsurancePriceTableS { get; set; }
    }
}
