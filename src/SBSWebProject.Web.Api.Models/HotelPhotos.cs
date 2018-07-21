using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelPhotos
    {
        public long Id { get; set; }
        public Hotels HotelItem { get; set; }
        public Files FileItem { get; set; }
        public string Description { get; set; }
    }
}
