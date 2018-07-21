using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class InsuranceAgeInterval : Entity {
        public virtual int? FromYear { get; set; }
        public virtual int? ToYear { get; set; }
        public virtual IList<InsurancePriceTable> InsurancePriceTableS { get; set; }
    }
}
