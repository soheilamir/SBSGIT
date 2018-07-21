using System;
using System.Text;
using System.Collections.Generic;
using SBSWebProject.Data.Entities;


namespace SBSWebProject.Web.Api.Models
{
    public class AirlineClasses
    {
        public virtual long Id { get; set; }
        public virtual Airlines AirlineItem { get; set; }
        public virtual string FlightClassName { get; set; }
        public virtual IList<AirlineSubClasses> AirlineSubClassesS { get; set; }
    }
}
