using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelRoomBeds
    {
        public long Id { get; set; }
        public string BedName { get; set; }
        public int? BedWidth { get; set; }
        public int? BedHeight { get; set; }
        public IList<HotelRoom> HotelRoomS { get; set; }
    }
}
