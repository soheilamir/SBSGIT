using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class FlightFreeServices
    {
        public virtual long Id { get; set; }
        public virtual FlightNumbers FlightNumberItem { get; set; }
        public virtual string ServiceName { get; set; }
        public virtual string ServiceDescription { get; set; }
    }
}
