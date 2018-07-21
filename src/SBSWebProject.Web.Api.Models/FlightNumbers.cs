using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public class FlightNumbers {

        public virtual long Id { get; set; }
        public virtual AirlineClassPath AirlineClassPathItem { get; set; }
        public virtual AirlineSubClasses AirlineSubClassItem { get; set; }
        public virtual City SourceCityItem { get; set; }
        public virtual City DestinationCityItem { get; set; }
        public virtual Airplane AirplaneItem { get; set; }
        public virtual int? FlightNumber { get; set; }
        public virtual DateTime? TakeOffTime { get; set; }
        public virtual DateTime? LandingTime { get; set; }
        public virtual DateTime? TransitTime { get; set; }
        public virtual string TicketValidation { get; set; }
        public virtual IList<FlightFreeServices> FlightFreeServicesesS { get; set; }
        public virtual IList<FlightStopOver> FlightStopOverS { get; set; }
        public virtual IList<ResponseAirplaneTicket> ResponseAirplaneTicketS { get; set; }
    }
}
