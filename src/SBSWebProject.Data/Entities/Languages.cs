using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class Languages : Entity
    {
        //public virtual long Id { get; set; }
        public virtual string LanguageName { get; set; }
        public virtual string ISO6391 { get; set; }
        public virtual string ISO6392 { get; set; }
        public virtual string TextDirection { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<AirlineNameByLanguage> AirlineNameByLanguageS { get; set; }
        public virtual IList<AirportNameByLanguage> AirportNameByLanguageS { get; set; }
        public virtual IList<CityNameByLanguage> CityNameByLanguageS { get; set; }
        public virtual IList<CityPublicPlaceNameByLanguage> CityPublicPlaceNameByLanguageS { get; set; }
        public virtual IList<CountryNameByLanguage> CountryNameByLanguageS { get; set; }
        public virtual IList<FacilitiesNameByLanguage> FacilitiesNameByLanguageS { get; set; }
        public virtual IList<HotelNameByLanguage> HotelNameByLanguageS { get; set; }
        public virtual IList<StateProvinceNameByLanguage> StateProvinceNameByLanguageS { get; set; }
        public virtual IList<UserLanguages> UserLanguagesS { get; set; }
        public virtual IList<HotelRoomTypeNameByLanguage> HotelRoomTypeNameByLanguageS { get; set; }
    }
}
