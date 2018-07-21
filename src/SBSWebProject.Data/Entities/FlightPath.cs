using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public partial class FlightPath : Entity
    {
        //public virtual long Id { get; set; }
        public virtual City SourceCityItem { get; set; }
        public virtual City DestinationCityItem { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<AirlineClassPath> AirlineClassPathS { get; set; }
    }
}
