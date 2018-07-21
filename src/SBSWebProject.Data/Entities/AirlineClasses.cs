using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{

    public class AirlineClasses : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Airlines AirlineItem { get; set; }
        public virtual string FlightClassName { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<AirlineSubClasses> AirlineSubClassesS { get; set; }
    }
}
