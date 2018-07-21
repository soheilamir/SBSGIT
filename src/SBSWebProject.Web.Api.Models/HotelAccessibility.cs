using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelAccessibility
    {
        public long Id { get; set; }
        public Hotels HotelsItem { get; set; }
        public CityPublicPlace CityPublicPlaceItem { get; set; }
        public int? Distance { get; set; }
        public int? TimeWithCar { get; set; }
        public int? TimeWithWalk { get; set; }
    }
}
