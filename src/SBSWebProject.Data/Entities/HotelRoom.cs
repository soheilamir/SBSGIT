using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class HotelRoom : Entity {
        public virtual Hotels HotelItem { get; set; }
        public virtual HotelRoomBeds HotelRoomBedItem { get; set; }
        public virtual HotelRoomType HotelRoomTypeItem { get; set; }
        public virtual int? RoomCount { get; set; }
        public virtual int? Dimension { get; set; }
        public virtual int? MaxAdults { get; set; }
        public virtual int? MaxChildren { get; set; }
        public virtual int? MaxGuests { get; set; }
        public virtual int? ChildNum { get; set; }
        public virtual string ChildAge { get; set; }
        public virtual bool HasBreakfast { get; set; }
        public virtual bool HasLunch { get; set; }
        public virtual bool HasDinner { get; set; }
        public virtual IList<HotelOrRoomConditions> HotelOrRoomConditionsS { get; set; }
        public virtual IList<HotelRoomComments> HotelRoomCommentsS { get; set; }
        public virtual IList<HotelRoomNightPrice> HotelRoomNightPriceS { get; set; }
        public virtual IList<HotelRoomPhotos> HotelRoomPhotosS { get; set; }
    }
}
