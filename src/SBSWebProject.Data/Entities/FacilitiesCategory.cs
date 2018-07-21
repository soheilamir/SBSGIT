using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class FacilitiesCategory : Entity {
        public virtual string CategoryName { get; set; }
        public virtual IList<Facilities> FacilitiesS { get; set; }
    }
}
