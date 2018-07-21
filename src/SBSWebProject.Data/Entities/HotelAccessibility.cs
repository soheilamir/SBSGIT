using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelAccessibility : Entity {
        public virtual Hotels HotelsItem { get; set; }
        public virtual CityPublicPlace CityPublicPlaceItem { get; set; }
        public virtual int? Distance { get; set; }
        public virtual int? TimeWithCar { get; set; }
        public virtual int? TimeWithWalk { get; set; }
    }
}
