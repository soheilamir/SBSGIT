using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class InsuranceTravelInterval : Entity {
        public virtual int? FromDays { get; set; }
        public virtual int? ToDays { get; set; }
        public virtual string Title { get; set; }
        public virtual IList<InsurancePriceTable> InsurancePriceTableS { get; set; }
    }
}
