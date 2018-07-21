using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class Languages
    {
        public virtual long Id { get; set; }
        public virtual string LanguageName { get; set; }
        public virtual string ISO6391 { get; set; }
        public virtual string ISO6392 { get; set; }
        public virtual string TextDirection { get; set; }
        public virtual IList<AirlineNameByLanguage> AirlineNameByLanguageS { get; set; }
        public virtual IList<AirportNameByLanguage> AirportNameByLanguageS { get; set; }
        public virtual IList<CityNameByLanguage> CityNameByLanguageS { get; set; }
        public virtual IList<CountryNameByLanguage> CountryNameByLanguageS { get; set; }
        public virtual IList<StateProvinceNameByLanguage> StateProvinceNameByLanguageS { get; set; }
        public virtual IList<UserLanguages> UserLanguagesS { get; set; }
        public virtual IList<HotelRoomTypeNameByLanguage> HotelRoomTypeNameByLanguageS { get; set; }
    }
}
