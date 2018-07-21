using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class AirportNameByLanguage : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Languages LanguagesItem { get; set; }
        public virtual Airports AirportsItem { get; set; }
        public virtual string AirportName { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
