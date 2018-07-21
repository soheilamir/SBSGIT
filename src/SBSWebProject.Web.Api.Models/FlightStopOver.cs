using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class FlightStopOver
    {
        public virtual long Id { get; set; }
        public virtual FlightNumbers FlightNumberItem { get; set; }
        public virtual City StopCity { get; set; }
        public virtual DateTime? StopTime { get; set; }
    }
}
