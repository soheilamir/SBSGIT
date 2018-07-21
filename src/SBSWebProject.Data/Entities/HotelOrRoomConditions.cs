using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelOrRoomConditions : Entity {
        public virtual Hotels HotelItem { get; set; }
        public virtual HotelRoom HotelroomItem { get; set; }
        public virtual string Condition { get; set; }
    }
}
