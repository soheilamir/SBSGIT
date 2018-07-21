using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class FlightNumbers : Entity {

        //public virtual long Id { get; set; }
        public virtual AirlineSubClasses AirlineSubClassesItem { get; set; }
        public virtual AirlineClassPath AirlineClassPathItem { get; set; }
        public virtual Airplane AirplaneItem { get; set; }
        public virtual int? FlightNumber { get; set; }
        public virtual DateTime? TakeOffTime { get; set; }
        public virtual DateTime? LandingTime { get; set; }
        public virtual DateTime? TransitTime { get; set; }
        public virtual string TicketValidation { get; set; }
        public virtual bool? IsActive { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<FlightFreeServices> FlightFreeServicesesS { get; set; }
        public virtual IList<FlightStopOver> FlightStopOverS { get; set; }
        public virtual IList<ResponseAirplaneTicket> ResponseAirplaneTicketS { get; set; }
    }
}
