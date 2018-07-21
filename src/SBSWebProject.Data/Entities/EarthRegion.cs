using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class EarthRegion : Entity
    {
        //public virtual long Id { get; set; }
        public virtual string EarthRegionName { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<Country> CountryS { get; set; }
    }
}
