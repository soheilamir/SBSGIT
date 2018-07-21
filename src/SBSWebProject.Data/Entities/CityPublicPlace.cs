using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class CityPublicPlace : Entity {
        public virtual City CityItem { get; set; }
        public virtual IList<CityPublicPlaceNameByLanguage> CityPublicPlaceNameByLanguageS { get; set; }
        public virtual IList<HotelAccessibility> HotelAccessibilityS { get; set; }
    }
}
