using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelFacilities : Entity {
        public virtual Hotels HotelItem { get; set; }
        public virtual Facilities FacilitiesItem { get; set; }
    }
}
