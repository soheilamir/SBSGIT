using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class InsuranceOrders
    {
        public long Id { get; set; }
        public InsurancePriceTable InsurancePriceTableItem { get; set; }
        public Persons PersonsItem { get; set; }
        public DateTime? SubmitDate { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public DateTime? TravelStartDate { get; set; }
        public DateTime? TravelEndDate { get; set; }
    }
}
