using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class InsurancePriceTable
    {
        public long Id { get; set; }
        public InsuranceZone InsuranceZoneItem { get; set; }
        public InsuranceTravelInterval InsuranceTravelIntervalItem { get; set; }
        public InsuranceAgeInterval InsuranceAgeIntervalItem { get; set; }
        public long? Price { get; set; }
        public IList<InsuranceOrders> InsuranceOrdersS { get; set; }
    }
}
