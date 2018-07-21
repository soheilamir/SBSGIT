using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class InsuranceOrders : Entity {
        public virtual InsurancePriceTable InsurancePriceTableItem { get; set; }
        public virtual Persons PersonsItem { get; set; }
        public virtual DateTime? SubmitDate { get; set; }
        public virtual DateTime? IssuanceDate { get; set; }
        public virtual DateTime? TravelStartDate { get; set; }
        public virtual DateTime? TravelEndDate { get; set; }
    }
}
