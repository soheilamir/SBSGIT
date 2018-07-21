using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class Hotels
    {
        public long Id { get; set; }
        public City CityItem { get; set; }
        public byte? Stars { get; set; }
        public byte? Rate { get; set; }
        public string Description { get; set; }
        public bool? FreeWifi { get; set; }
        public string Address { get; set; }
        public IList<HotelAccessibility> HotelAccessibilityS { get; set; }
        public IList<HotelComments> HotelCommentsS { get; set; }
        public IList<HotelFacilities> HotelFacilitiesS { get; set; }
        public IList<HotelNameByLanguage> HotelNameByLanguageS { get; set; }
        public IList<HotelOrRoomConditions> HotelOrRoomConditionsS { get; set; }
        public IList<HotelPhotos> HotelPhotosS { get; set; }
        public IList<HotelRoom> HotelRoomS { get; set; }
    }
}
