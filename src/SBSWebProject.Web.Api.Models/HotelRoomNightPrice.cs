using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelRoomNightPrice
    {
        public long Id { get; set; }
        public HotelRoom HotelRoomItem { get; set; }
        public string Date { get; set; }
        public long? Price { get; set; }
        public string Description { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
