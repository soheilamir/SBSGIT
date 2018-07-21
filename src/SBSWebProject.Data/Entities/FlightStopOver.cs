using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public class FlightStopOver : Entity
    {
        //public virtual long Id { get; set; }
        public virtual FlightNumbers FlightNumberItem { get; set; }
        public virtual City StopCity { get; set; }
        public virtual DateTime? StopTime { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
