using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class RequestAirplaneTicket
    {
        public virtual long Id { get; set; }
        public virtual RequestAirplaneService RequestAirplaneServiceItem { get; set; }
        public virtual City from { get; set; } //SourceCityItem
        public virtual City to { get; set; }//DestinationCityItem
        public virtual long? AdminUserId { get; set; }
        public virtual ComboBox cabinClass { get; set; } //TicketClass in Entity
        public virtual ComboBox ticketType { get; set; } // IsInTicket in Entity
        public virtual ComboBox journeyType { get; set; }
        public virtual bool? selectedFlexibleDate { get; set; } // IsDateFlexible in Entity
        public virtual ComboBox PreferredTime { get; set; }
        public virtual string departingDate { get; set; }
        public virtual string returningDate { get; set; }
        public virtual RequestStatus PlaneTicketStatusId { get; set; }
        //public virtual IList<RequestAirplaneTicketPassenger> RequestAirplaneTicketPassengerS { get; set; }
        public virtual IList<ResponseAirplaneTicket> flightRecomend { get; set; }
        public virtual IList<ComboBox> airlineList { get; set; }
    }
}
