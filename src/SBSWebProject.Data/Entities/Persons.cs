using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class Persons : Entity {
        public virtual int? PersonType { get; set; }
        public virtual IList<InsuranceOrders> InsuranceOrdersS { get; set; }
    }
}
