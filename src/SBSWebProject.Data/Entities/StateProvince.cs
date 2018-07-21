using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class StateProvince : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Country CountryItem { get; set; }
        public virtual byte? TelCode { get; set; }
        public virtual string CharCode { get; set; }
        public virtual int? Priority { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<StateProvinceNameByLanguage> StateProvinceNameByLanguageS { get; set; }
        public virtual IList<City> CityS { get; set; }

    }
}
