using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class Airplane
    {
        public virtual long Id { get; set; }
        public virtual string Company { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<FlightNumbers> FlightNumberS { get; set; }
    }
}
