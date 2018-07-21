using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelPhotos : Entity {
        public virtual Hotels HotelItem { get; set; }
        public virtual Files FileItem { get; set; }
        public virtual string Description { get; set; }
    }
}
