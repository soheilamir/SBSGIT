using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelRoomPhotos
    {
        public long Id { get; set; }
        public HotelRoom HotelRoomItem { get; set; }
        public Files FileItem { get; set; }
        public string Descriptopn { get; set; }
    }
}
