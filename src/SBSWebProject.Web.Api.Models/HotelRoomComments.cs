using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelRoomComments
    {
        public long Id { get; set; }
        public HotelRoom HotelRoomItem { get; set; }
        public Users UserItem { get; set; }
        public string Comments { get; set; }
    }
}
