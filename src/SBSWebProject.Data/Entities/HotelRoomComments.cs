using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelRoomComments : Entity {
        public virtual HotelRoom HotelRoomItem { get; set; }
        public virtual Users UserItem { get; set; }
        public virtual string Comments { get; set; }
    }
}
