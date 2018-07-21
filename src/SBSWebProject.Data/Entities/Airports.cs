using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class Airports : Entity
    {
        //public virtual long Id { get; set; }
        public virtual City CityItem { get; set; }
        public virtual string Address { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<AirportNameByLanguage> AirportNamebyLanguageS { get; set; }
    }
}
