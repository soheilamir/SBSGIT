using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public partial class FlightPath
    {
        public virtual long Id { get; set; }
        public virtual City SourceCityItem { get; set; }
        public virtual City DestinationCityItem { get; set; }
        public virtual IList<AirlineClassPath> AirlineClassPathS { get; set; }
    }
}
