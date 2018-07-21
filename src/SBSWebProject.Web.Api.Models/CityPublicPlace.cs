using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class CityPublicPlace
    {
        public long Id { get; set; }
        public City CityItem { get; set; }
        public IList<CityPublicPlaceNameByLanguage> CityPublicPlaceNameByLanguageS { get; set; }
        public IList<HotelAccessibility> HotelAccessibilityS { get; set; }
    }
}
