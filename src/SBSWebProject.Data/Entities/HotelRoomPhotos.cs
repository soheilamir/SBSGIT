using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelRoomPhotos : Entity {
        public virtual HotelRoom HotelRoomItem { get; set; }
        public virtual Files FileItem { get; set; }
        public virtual string Descriptopn { get; set; }
    }
}
