using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelNameByLanguage : Entity {
        public virtual Languages LanguagesItem { get; set; }
        public virtual Hotels HotelItem { get; set; }
        public virtual string Name { get; set; }
    }
}
