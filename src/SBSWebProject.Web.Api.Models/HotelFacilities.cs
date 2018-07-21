using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelFacilities
    {
        public long Id { get; set; }
        public Hotels HotelItem { get; set; }
        public Facilities FacilitiesItem { get; set; }
    }
}
