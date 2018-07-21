using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class Hotels : Entity {
        public virtual City CityItem { get; set; }
        public virtual byte? Stars { get; set; }
        public virtual byte? Rate { get; set; }
        public virtual string Description { get; set; }
        public virtual bool? FreeWifi { get; set; }
        public virtual string Address { get; set; }
        public virtual IList<HotelAccessibility> HotelAccessibilityS { get; set; }
        public virtual IList<HotelComments> HotelCommentsS { get; set; }
        public virtual IList<HotelFacilities> HotelFacilitiesS { get; set; }
        public virtual IList<HotelNameByLanguage> HotelNameByLanguageS { get; set; }
        public virtual IList<HotelOrRoomConditions> HotelOrRoomConditionsS { get; set; }
        public virtual IList<HotelPhotos> HotelPhotosS { get; set; }
        public virtual IList<HotelRoom> HotelRoomS { get; set; }
    }
}
