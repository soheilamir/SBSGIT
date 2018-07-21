using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelRoomBeds : Entity {
        public virtual string BedName { get; set; }
        public virtual int? BedWidth { get; set; }
        public virtual int? BedHeight { get; set; }
        public virtual IList<HotelRoom> HotelRoomS { get; set; }
    }
}
