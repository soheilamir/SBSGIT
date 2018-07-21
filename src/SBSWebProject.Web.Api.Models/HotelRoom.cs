using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelRoom
    {
        public long Id { get; set; }
        public Hotels HotelItem { get; set; }
        public HotelRoomBeds HotelRoomBedItem { get; set; }
        public HotelRoomType HotelRoomTypeItem { get; set; }
        public int? RoomCount { get; set; }
        public int? Dimension { get; set; }
        public int? MaxAdults { get; set; }
        public int? MaxChildren { get; set; }
        public int? MaxGuests { get; set; }
        public int? ChildNum { get; set; }
        public string ChildAge { get; set; }
        public bool HasBreakfast { get; set; }
        public bool HasLunch { get; set; }
        public bool HasDinner { get; set; }
        public HotelRoomNightPrice ActiveNightPriceItem { get; set; }
        public IList<HotelOrRoomConditions> HotelOrRoomConditionsS { get; set; }
        public IList<HotelRoomComments> HotelRoomCommentsS { get; set; }
        public IList<HotelRoomNightPrice> HotelRoomNightPriceS { get; set; }
        public IList<HotelRoomPhotos> HotelRoomPhotosS { get; set; }
    }
}
