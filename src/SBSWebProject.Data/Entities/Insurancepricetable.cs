using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class InsurancePriceTable : Entity {
        public virtual InsuranceZone InsuranceZoneItem { get; set; }
        public virtual InsuranceTravelInterval InsuranceTravelIntervalItem { get; set; }
        public virtual InsuranceAgeInterval InsuranceAgeIntervalItem { get; set; }
        public virtual long? Price { get; set; }
        public virtual IList<InsuranceOrders> InsuranceOrdersS { get; set; }
    }
}
