using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class AirlineSubClasses
    {
        public virtual long Id { get; set; }
        public virtual AirlineClasses AirlineClassesItem { get; set; }
        public virtual string AirlineSubClassName { get; set; }
        public virtual IList<FlightNumbers> FlightNumberS { get; set; }
    }
}
