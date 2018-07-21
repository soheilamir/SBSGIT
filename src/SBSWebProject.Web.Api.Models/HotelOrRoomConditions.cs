using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelOrRoomConditions
    {
        public long Id { get; set; }
        public Hotels HotelItem { get; set; }
        public HotelRoom HotelroomItem { get; set; }
        public string Condition { get; set; }
    }
}
