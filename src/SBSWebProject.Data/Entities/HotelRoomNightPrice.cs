using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelRoomNightPrice : Entity {
        public virtual HotelRoom HotelRoomItem { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual long? Price { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
