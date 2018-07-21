using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelComments : Entity {
        public virtual Hotels HotelItem { get; set; }
        public virtual Users UserItem { get; set; }
        public virtual string Comments { get; set; }
        public virtual DateTime? Date { get; set; }
    }
}
