using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class RequestAirplaneTicket : Entity
    {
        //public virtual long Id { get; set; }
        public virtual RequestAirplaneService RequestAirplaneServiceItem { get; set; }
        public virtual City SourceCityItem { get; set; }
        public virtual City DestinationCityItem { get; set; }
        public virtual long? AdminUserId { get; set; }
        public virtual int? TicketClass { get; set; }
        public virtual int? TicketType { get; set; }
        public virtual int? JourneyType { get; set; }
        public virtual bool? IsDateFlexible { get; set; }
        public virtual int? PreferredTime { get; set; }
        public virtual DateTime? DepartureDate { get; set; }
        public virtual DateTime? ReturningDate { get; set; }
        public virtual RequestStatus PlaneTicketStatusId { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<RequestAirplaneTicketPassenger> RequestAirplaneTicketPassengerS { get; set; }
        public virtual IList<ResponseAirplaneTicket> ResponseAirplaneTicketS { get; set; }
        public virtual IList<AirplaneTicketPreferedAirlines> AirplaneTicketPreferedAirlinesS { get; set; }
    }
}
