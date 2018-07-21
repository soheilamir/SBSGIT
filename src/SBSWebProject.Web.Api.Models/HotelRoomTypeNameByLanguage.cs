using System;
using System.Collections.Generic;

namespace SBSWebProject.Web.Api.Models
{
    public class HotelRoomTypeNameByLanguage
    {
        public long Id { get; set; }
        public Languages LanguagesItem { get; set; }
        public HotelRoomType HotelRoomTypeItem { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
